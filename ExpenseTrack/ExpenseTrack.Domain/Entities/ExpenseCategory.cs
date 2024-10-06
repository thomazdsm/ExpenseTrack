using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrack.Domain.Entities
{
    public class ExpenseCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        // Relação com Despesas (1:N)
        public ICollection<Expense> Expenses { get; set; }
    }
}
