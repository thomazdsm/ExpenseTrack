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
    public class ReceiptService : IReceiptService
    {
        private readonly IReceiptRepository _repository;
        private readonly IMapper _mapper;

        public ReceiptService(IReceiptRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task AddAsync(ReceiptViewModel receiptViewModel)
        {
            var receipt = _mapper.Map<Receipt>(receiptViewModel);
            await _repository.AddAsync(receipt);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<ReceiptViewModel>> GetAllAsync()
        {
            var receipts = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<ReceiptViewModel>>(receipts);
        }

        public async Task<ReceiptViewModel> GetByIdAsync(int id)
        {
            var receipt = await _repository.GetByIdAsync(id);
            return _mapper.Map<ReceiptViewModel>(receipt);
        }

        public async Task UpdateAsync(ReceiptViewModel receiptViewModel)
        {
            var receipt = _mapper.Map<Receipt>(receiptViewModel);
            await _repository.UpdateAsync(receipt);
        }
    }
}
