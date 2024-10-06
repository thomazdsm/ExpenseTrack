using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrack.Domain.Entities
{
    public class Expense
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

        // Navegação
        public virtual ExpenseCategory ExpenseCategory { get; set; }
        public virtual Currency Currency { get; set; }
        public virtual ExchangeRate ExchangeRate { get; set; }
        public virtual Receipt Receipt { get; set; }
        public virtual IdentityUser User { get; set; }
    }
}
