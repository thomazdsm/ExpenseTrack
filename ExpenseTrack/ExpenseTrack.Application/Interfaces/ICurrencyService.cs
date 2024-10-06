using ExpenseTrack.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrack.Application.Interfaces
{
    public interface ICurrencyService
    {
        Task<IEnumerable<CurrencyViewModel>> GetAllAsync();
        Task<CurrencyViewModel> GetByIdAsync(int id);
        Task AddAsync(CurrencyViewModel currency);
        Task UpdateAsync(CurrencyViewModel currency);
        Task DeleteAsync(int id);
    }
}
