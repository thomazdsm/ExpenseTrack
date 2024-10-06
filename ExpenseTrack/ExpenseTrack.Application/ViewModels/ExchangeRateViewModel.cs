using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrack.Application.ViewModels
{
    public class ExchangeRateViewModel
    {
        public int Id { get; set; }
        public int BaseCurrencyId { get; set; }
        public int TargetCurrencyId { get; set; }
        public decimal Rate { get; set; }
        public DateTime EffectiveDate { get; set; }

        // Informações adicionais
        public string BaseCurrencyCode { get; set; }
        public string TargetCurrencyCode { get; set; }
    }
}
