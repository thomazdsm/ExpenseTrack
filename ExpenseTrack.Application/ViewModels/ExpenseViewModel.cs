using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrack.Application.ViewModels
{
    public class ExpenseViewModel
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int ExpenseCategoryId { get; set; }
        public decimal Amount { get; set; }
        public int CurrencyId { get; set; }
        public decimal ConvertedAmount { get; set; }
        public int ExchangeRateId { get; set; }
        public string Description { get; set; }
        public int? ReceiptId { get; set; }
        public string Status { get; set; } // Ex: Pendente, Aprovada, Rejeitada
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        // Informações adicionais
        public string CategoryName { get; set; }
        public string CurrencyCode { get; set; }
        public decimal ExchangeRate { get; set; }
        public string ReceiptFilePath { get; set; }
    }
}
