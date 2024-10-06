using ExpenseTrack.Domain.Entities;
using ExpenseTrack.Domain.Interfaces;
using ExpenseTrack.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrack.Infra.Data.Repositories
{
    public class ExchangeRateRepository : IExchangeRateRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;
        private readonly string _baseUrl;

        public ExchangeRateRepository(ApplicationDbContext context, HttpClient httpClient, IConfiguration configuration)
        {
            _context = context;
            _httpClient = httpClient;
            _apiKey = configuration["ExchangeRateApi:ApiKey"];
            _baseUrl = configuration["ExchangeRateApi:BaseUrl"] ?? "https://v6.exchangerate-api.com/v6";
        }

        public async Task AddAsync(ExchangeRate exchangeRate)
        {
            await _context.ExchangeRates.AddAsync(exchangeRate);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var exchangeRate = await _context.ExchangeRates.FindAsync(id);
            if (exchangeRate != null)
            {
                _context.ExchangeRates.Remove(exchangeRate);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<ExchangeRate>> GetAllAsync()
        {
            return await _context.ExchangeRates
                .Include(er => er.BaseCurrency)
                .Include(er => er.TargetCurrency)
                .ToListAsync();
        }

        public async Task<ExchangeRate> GetByIdAsync(int id)
        {
            return await _context.ExchangeRates
                .Include(er => er.BaseCurrency)
                .Include(er => er.TargetCurrency)
                .FirstOrDefaultAsync(er => er.Id == id);
        }

        public async Task UpdateAsync(ExchangeRate exchangeRate)
        {
            _context.ExchangeRates.Update(exchangeRate);
            await _context.SaveChangesAsync();
        }

        // ExchangeRate API
        public async Task<ExchangeRate> GetLatestRateAsync(int targetCurrencyId, int baseCurrencyId)
        {
            Currency baseCurrency = _context.Currencies.FindAsync(baseCurrencyId).Result;
            Currency targetCurrency = _context.Currencies.FindAsync(targetCurrencyId).Result;


            var url = $"{_baseUrl}/{_apiKey}/pair/{baseCurrency.Code.ToUpper()}/{targetCurrency.Code.ToUpper()}";
            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
                throw new Exception($"Erro ao chamar a ExchangeRate-API: {response.ReasonPhrase}");

            var content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ExchangeRateResponse>(content);

            if (result == null || result.Result != "success")
                throw new Exception("Resposta inválida da ExchangeRate-API.");

            ExchangeRate exchangeRate = new ExchangeRate();
            exchangeRate.TargetCurrencyId = targetCurrencyId;
            exchangeRate.BaseCurrencyId = baseCurrencyId;
            exchangeRate.Rate = Convert.ToDecimal(result.Conversion_Rate, CultureInfo.InvariantCulture);
            exchangeRate.EffectiveDate = DateTime.Now;

            return exchangeRate;

        }
    }
}
