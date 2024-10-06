using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrack.Application.ViewModels
{
    public class ExpenseCategoryViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O Nome é obrigatório!")]
        [MinLength(3)]
        [MaxLength(100)]
        [DisplayName("Nome da Categoria")]
        public string Name { get; set; }

        [DisplayName("Descrição da Categoria")]
        public string Description { get; set; }
    }
}
