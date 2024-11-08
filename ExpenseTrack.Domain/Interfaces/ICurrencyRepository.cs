﻿using ExpenseTrack.Domain.Entities;

namespace ExpenseTrack.Domain.Interfaces
{
    public interface ICurrencyRepository
    {
        Task<IEnumerable<Currency>> GetAllAsync();
        Task<Currency> GetByIdAsync(int id);
        Task<Currency> GetByCodeAsync(string code);
        Task AddAsync(Currency currency);
        Task UpdateAsync(Currency currency);
        Task DeleteAsync(int id);
    }
}
