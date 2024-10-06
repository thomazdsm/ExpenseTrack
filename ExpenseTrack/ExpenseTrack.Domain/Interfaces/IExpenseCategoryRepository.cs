using ExpenseTrack.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrack.Domain.Interfaces
{
    public interface IExpenseCategoryRepository
    {
        Task<IEnumerable<ExpenseCategory>> GetAllAsync();
        Task<ExpenseCategory> GetByIdAsync(int id);
        Task AddAsync(ExpenseCategory category);
        Task UpdateAsync(ExpenseCategory category);
        Task DeleteAsync(int id);
    }
}
