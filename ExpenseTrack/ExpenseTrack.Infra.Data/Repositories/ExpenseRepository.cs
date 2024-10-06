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
    public class ExpenseRepository : IExpenseRepository
    {
        private readonly ApplicationDbContext _context;

        public ExpenseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Expense expense)
        {
            await _context.Expenses.AddAsync(expense);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var expense = await _context.Expenses.FindAsync(id);
            if (expense != null)
            {
                _context.Expenses.Remove(expense);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Expense>> GetAllAsync()
        {
            return await _context.Expenses
                .Include(e => e.ExpenseCategory)
                .Include(e => e.Currency)
                .Include(e => e.ExchangeRate)
                .Include(e => e.Receipt)
                .ToListAsync();
        }

        public async Task<Expense> GetByIdAsync(int id)
        {
            return await _context.Expenses
                .Include(e => e.ExpenseCategory)
                .Include(e => e.Currency)
                .Include(e => e.ExchangeRate)
                .Include(e => e.Receipt)
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task UpdateAsync(Expense expense)
        {
            _context.Expenses.Update(expense);
            await _context.SaveChangesAsync();
        }
    }
}
