using System;
using System.Collections.Generic;

namespace TaxiAppsWebAPICore.TaxiModels
{
    public partial class TabCurrencies
    {
        public TabCurrencies()
        {
            TabCommonCurrency = new HashSet<TabCommonCurrency>();
        }

        public long Currenciesid { get; set; }
        public long? Countryid { get; set; }
        public string Currency { get; set; }
        public string Code { get; set; }
        public string Symbol { get; set; }
        public string ThousandSeparator { get; set; }
        public string DecimalSeparator { get; set; }
        public int? IsActive { get; set; }
        public int? IsDelete { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual TabCountry Country { get; set; }
        public virtual ICollection<TabCommonCurrency> TabCommonCurrency { get; set; }
    }
}
