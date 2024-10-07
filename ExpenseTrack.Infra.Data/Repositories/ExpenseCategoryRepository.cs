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
    public class ExpenseCategoryRepository : IExpenseCategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public ExpenseCategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(ExpenseCategory category)
        {
            await _context.ExpenseCategories.AddAsync(category);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var category = await _context.ExpenseCategories.FindAsync(id);
            if (category != null)
            {
                _context.ExpenseCategories.Remove(category);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<ExpenseCategory>> GetAllAsync()
        {
            return await _context.ExpenseCategories.ToListAsync();
        }

        public async Task<ExpenseCategory> GetByIdAsync(int id)
        {
            return await _context.ExpenseCategories.FindAsync(id);
        }

        public async Task UpdateAsync(ExpenseCategory category)
        {
            _context.ExpenseCategories.Update(category);
            await _context.SaveChangesAsync();
        }
    }
}
