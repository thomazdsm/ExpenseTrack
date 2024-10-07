using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrack.Domain.Entities
{
    public class Receipt
    {
        public int Id { get; set; }
        public string FilePath { get; set; } // Caminho para o arquivo do recibo no armazenamento
        public DateTime UploadedAt { get; set; }
        public string UploadedBy { get; set; } // FK para User


        public virtual IdentityUser UploadedByUser { get; set; }
        public ICollection<Expense> Expenses { get; set; }
    }
}
