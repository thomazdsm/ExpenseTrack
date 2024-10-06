using AutoMapper;
using ExpenseTrack.Application.Interfaces;
using ExpenseTrack.Application.ViewModels;
using ExpenseTrack.Domain.Entities;
using ExpenseTrack.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrack.Application.Services
{
    public class ExpenseService : IExpenseService
    {
        private readonly IExpenseRepository _repository;
        private readonly IMapper _mapper;

        public ExpenseService(IExpenseRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task AddAsync(ExpenseViewModel expenseViewModel)
        {
            var expense = _mapper.Map<Expense>(expenseViewModel);
            await _repository.AddAsync(expense);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<ExpenseViewModel>> GetAllAsync()
        {
            var expenses = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<ExpenseViewModel>>(expenses);
        }

        public async Task<ExpenseViewModel> GetByIdAsync(int id)
        {
            var expense = await _repository.GetByIdAsync(id);
            return _mapper.Map<ExpenseViewModel>(expense);
        }

        public async Task UpdateAsync(ExpenseViewModel expenseViewModel)
        {
            var expense = _mapper.Map<Expense>(expenseViewModel);
            await _repository.UpdateAsync(expense);
        }
    }
}
