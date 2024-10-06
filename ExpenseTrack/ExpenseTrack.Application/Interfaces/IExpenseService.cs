using ExpenseTrack.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrack.Application.Interfaces
{
    public interface IExpenseService
    {
        Task<IEnumerable<ExpenseViewModel>> GetAllAsync();
        Task<ExpenseViewModel> GetByIdAsync(int id);
        Task AddAsync(ExpenseViewModel expenseViewModel);
        Task UpdateAsync(ExpenseViewModel expenseViewModel);
        Task DeleteAsync(int id);
    }
}
