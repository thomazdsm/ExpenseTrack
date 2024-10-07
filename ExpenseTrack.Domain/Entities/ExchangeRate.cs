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

    public class ExchangeRateResponse
    {
        public string Result { get; set; }
        public string Documentation { get; set; }
        public string Terms_of_use { get; set; }
        public string Time_last_update_unix { get; set; }
        public string Time_last_update_utc { get; set; }
        public string Time_next_update_unix { get; set; }
        public string Time_next_update_utc { get; set; }
        public string Base_code { get; set; }
        public string Target_code { get; set; }
        public string Conversion_Rate { get; set; }
    }
}
