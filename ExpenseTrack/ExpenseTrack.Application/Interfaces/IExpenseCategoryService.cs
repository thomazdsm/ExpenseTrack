using ExpenseTrack.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrack.Application.Interfaces
{
    public interface IExpenseCategoryService
    {
        Task<IEnumerable<ExpenseCategoryViewModel>> GetAllAsync();
        Task<ExpenseCategoryViewModel> GetByIdAsync(int id);
        Task AddAsync(ExpenseCategoryViewModel category);
        Task UpdateAsync(ExpenseCategoryViewModel category);
        Task DeleteAsync(int id);
    }
}
