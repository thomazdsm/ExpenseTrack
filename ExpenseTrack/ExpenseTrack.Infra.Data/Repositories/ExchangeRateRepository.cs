using ExpenseTrack.Domain.Entities;
using ExpenseTrack.Domain.Interfaces;
using ExpenseTrack.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrack.Infra.Data.Repositories
{
    public class ExchangeRateRepository : IExchangeRateRepository
    {
        private readonly ApplicationDbContext _context;

        public ExchangeRateRepository(ApplicationDbContext context)
        {
            _context = context;
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
    }
}
