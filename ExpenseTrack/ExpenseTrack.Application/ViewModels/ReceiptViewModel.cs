using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrack.Application.ViewModels
{
    public class ReceiptViewModel
    {
        public int Id { get; set; }
        public string FilePath { get; set; }
        public DateTime UploadedAt { get; set; }
        public string UploadedBy { get; set; }

        // Informações adicionais
        public string UploadedByUserName { get; set; }
    }
}
