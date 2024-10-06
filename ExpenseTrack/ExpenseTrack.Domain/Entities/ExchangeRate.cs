using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrack.Domain.Entities
{
    public class ExchangeRate
    {
        public int Id { get; set; }
        public int BaseCurrencyId { get; set; } // Moeda base (ex: USD)
        public int TargetCurrencyId { get; set; } // Moeda alvo (ex: BRL)
        public decimal Rate { get; set; } // Taxa de câmbio
        public DateTime EffectiveDate { get; set; }

        // Navegação
        public virtual Currency BaseCurrency { get; set; }
        public virtual Currency TargetCurrency { get; set; }
    }
}
