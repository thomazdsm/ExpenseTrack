using ExpenseTrack.Domain.Entities;

namespace ExpenseTrack.Domain.Interfaces
{
    public interface IExchangeRateRepository
    {
        Task<IEnumerable<ExchangeRate>> GetAllAsync();
        Task<ExchangeRate> GetByIdAsync(int id);
        Task AddAsync(ExchangeRate exchangeRate);
        Task UpdateAsync(ExchangeRate exchangeRate);
        Task DeleteAsync(int id);

        // ExchangeRate API
        Task<ExchangeRate> GetLatestRateAsync(int targetCurrencyId, int baseCurrencyId);

    }
}
