using ExpenseTrack.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrack.Application.Interfaces
{
    public interface IReceiptService
    {
        Task<IEnumerable<ReceiptViewModel>> GetAllAsync();
        Task<ReceiptViewModel> GetByIdAsync(int id);
        Task AddAsync(ReceiptViewModel receiptViewModel);
        Task UpdateAsync(ReceiptViewModel receiptViewModel);
        Task DeleteAsync(int id);
    }
}
