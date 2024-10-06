using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrack.Domain.Entities
{
    public class Approval
    {
        public int Id { get; set; }
        public int ExpenseId { get; set; }
        public string ManagerId { get; set; }
        public string Action { get; set; } // e.g., Aprovada, Rejeitada - Verificar possibilidade de criar um Enumerable
        public string Comments { get; set; }
        public DateTime ApprovedAt { get; set; }

        // Navigation properties
        public virtual Expense Expense { get; set; }
        public virtual IdentityUser Manager { get; set; }
    }
}
