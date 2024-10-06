using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrack.Domain.Entities
{
    public class Currency
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }

        // Relação com Despesas (1:N)
        public ICollection<Expense> Expenses { get; set; }

        // Relação com Taxas de Câmbio (1:N)
        public ICollection<ExchangeRate> ExchangeRatesBase { get; set; }
        public ICollection<ExchangeRate> ExchangeRatesTarget { get; set; }
    }
}
