using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrack.Application.ViewModels
{
    public class CurrencyViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O Código é obrigatório!")]
        public string Code { get; set; }

        [Required(ErrorMessage = "O Nome é obrigatório!")]
        [MinLength(3)]
        [MaxLength(100)]
        [DisplayName("Nome da Moeda")]
        public string Name { get; set; }
    }
}
