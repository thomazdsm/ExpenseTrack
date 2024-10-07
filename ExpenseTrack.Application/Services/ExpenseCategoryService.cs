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
    public class ExpenseCategoryService : IExpenseCategoryService
    {
        private readonly IExpenseCategoryRepository _repository;
        private readonly IMapper _mapper;

        public ExpenseCategoryService(IExpenseCategoryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task AddAsync(ExpenseCategoryViewModel categoryViewModel)
        {
            var category = _mapper.Map<ExpenseCategory>(categoryViewModel);
            await _repository.AddAsync(category);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<ExpenseCategoryViewModel>> GetAllAsync()
        {
            var categories = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<ExpenseCategoryViewModel>>(categories);
        }

        public async Task<ExpenseCategoryViewModel> GetByIdAsync(int id)
        {
            var category = await _repository.GetByIdAsync(id);
            return _mapper.Map<ExpenseCategoryViewModel>(category);
        }

        public async Task UpdateAsync(ExpenseCategoryViewModel categoryViewModel)
        {
            var category = _mapper.Map<ExpenseCategory>(categoryViewModel);
            await _repository.UpdateAsync(category);
        }
    }
}
