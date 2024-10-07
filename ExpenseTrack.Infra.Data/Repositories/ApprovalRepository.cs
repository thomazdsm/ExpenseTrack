using ExpenseTrack.Domain.Entities;
using ExpenseTrack.Domain.Interfaces;
using ExpenseTrack.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrack.Infra.Data.Repositories
{
    public class ApprovalRepository : IApprovalRepository
    {
        private readonly ApplicationDbContext _context;

        public ApprovalRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task AddAsync(Approval approval)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Approval>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Approval> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Approval approval)
        {
            throw new NotImplementedException();
        }
    }
}
