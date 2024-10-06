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
    public class CurrencyService : ICurrencyService
    {
        private readonly ICurrencyRepository _repository;
        private readonly IMapper _mapper;

        public CurrencyService(ICurrencyRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task AddAsync(CurrencyViewModel currencyViewModel)
        {
            var currency = _mapper.Map<Currency>(currencyViewModel);
            await _repository.AddAsync(currency);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<CurrencyViewModel>> GetAllAsync()
        {
            var currencies = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<CurrencyViewModel>>(currencies);
        }

        public async Task<CurrencyViewModel> GetByIdAsync(int id)
        {
            var currency = await _repository.GetByIdAsync(id);
            return _mapper.Map<CurrencyViewModel>(currency);
        }

        public async Task UpdateAsync(CurrencyViewModel currencyViewModel)
        {
            var currency = _mapper.Map<Currency>(currencyViewModel);
            await _repository.UpdateAsync(currency);
        }
    }
}
