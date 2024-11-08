﻿using ExpenseTrack.Application.ViewModels;
using ExpenseTrack.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrack.Application.Interfaces
{
    public interface IExchangeRateService
    {
        Task<IEnumerable<ExchangeRateViewModel>> GetAllAsync();
        Task<ExchangeRateViewModel> GetByIdAsync(int id);
        Task AddAsync(ExchangeRateViewModel exchangeRate);
        Task UpdateAsync(ExchangeRateViewModel exchangeRate);
        Task DeleteAsync(int id);

        // ExchangeRate API
        Task<ExchangeRateViewModel> GetLatestRateAsync(int targetCurrencyId, int baseCurrencyId);
    }
}
