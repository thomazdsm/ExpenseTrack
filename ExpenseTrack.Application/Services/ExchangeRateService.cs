using AutoMapper;
using ExpenseTrack.Application.Interfaces;
using ExpenseTrack.Application.ViewModels;
using ExpenseTrack.Domain.Entities;
using ExpenseTrack.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrack.Application.Services
{
    public class ExchangeRateService : IExchangeRateService
    {
        private readonly IExchangeRateRepository _repository;
        private readonly IMapper _mapper;

        public ExchangeRateService(IExchangeRateRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task AddAsync(ExchangeRateViewModel exchangeRateViewModel)
        {
            var exchangeRate = _mapper.Map<ExchangeRate>(exchangeRateViewModel);
            await _repository.AddAsync(exchangeRate);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<ExchangeRateViewModel>> GetAllAsync()
        {
            var exchangeRates = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<ExchangeRateViewModel>>(exchangeRates);
        }

        public async Task<ExchangeRateViewModel> GetByIdAsync(int id)
        {
            var exchangeRate = await _repository.GetByIdAsync(id);
            return _mapper.Map<ExchangeRateViewModel>(exchangeRate);
        }

        public async Task UpdateAsync(ExchangeRateViewModel exchangeRateViewModel)
        {
            var exchangeRate = _mapper.Map<ExchangeRate>(exchangeRateViewModel);
            await _repository.UpdateAsync(exchangeRate);
        }

        // ExchangeRate API
        public async Task<ExchangeRateViewModel> GetLatestRateAsync(int targetCurrencyId, int baseCurrencyId)
        {
            var exchangeRate = await _repository.GetLatestRateAsync(targetCurrencyId, baseCurrencyId);
            return _mapper.Map<ExchangeRateViewModel>(exchangeRate);
        }
    }
}
