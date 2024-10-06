using ExpenseTrack.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrack.Domain.Interfaces
{
    public interface IReceiptRepository
    {
        Task<IEnumerable<Receipt>> GetAllAsync();
        Task<Receipt> GetByIdAsync(int id);
        Task AddAsync(Receipt receipt);
        Task UpdateAsync(Receipt receipt);
        Task DeleteAsync(int id);
    }
}
