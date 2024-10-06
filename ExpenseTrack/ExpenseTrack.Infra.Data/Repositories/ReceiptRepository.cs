using ExpenseTrack.Domain.Entities;
using ExpenseTrack.Domain.Interfaces;
using ExpenseTrack.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrack.Infra.Data.Repositories
{
    public class ReceiptRepository : IReceiptRepository
    {
        private readonly ApplicationDbContext _context;

        public ReceiptRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Receipt receipt)
        {
            await _context.Receipts.AddAsync(receipt);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var receipt = await _context.Receipts.FindAsync(id);
            if (receipt != null)
            {
                _context.Receipts.Remove(receipt);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Receipt>> GetAllAsync()
        {
            return await _context.Receipts
                .Include(r => r.UploadedByUser)
                .ToListAsync();
        }

        public async Task<Receipt> GetByIdAsync(int id)
        {
            return await _context.Receipts
                .Include(r => r.UploadedByUser)
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task UpdateAsync(Receipt receipt)
        {
            _context.Receipts.Update(receipt);
            await _context.SaveChangesAsync();
        }
    }
}
