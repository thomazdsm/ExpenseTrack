using ExpenseTrack.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrack.Domain.Interfaces
{
    public interface IApprovalRepository
    {
        Task<IEnumerable<Approval>> GetAllAsync();
        Task<Approval> GetByIdAsync(int id);
        Task AddAsync(Approval approval);
        Task UpdateAsync(Approval approval);
        Task DeleteAsync(int id);
    }
}
