using System;
using System.Collections.Generic;

namespace TaxiAppsWebAPICore.TaxiModels
{
    public partial class TabCommonCurrency
    {
        public TabCommonCurrency()
        {
            TabDriverWallet = new HashSet<TabDriverWallet>();
            TabServicelocation = new HashSet<TabServicelocation>();
            TabUser = new HashSet<TabUser>();
        }

        public long Currencyid { get; set; }
        public string Currencyname { get; set; }
        public string CurrencySymbol { get; set; }
        public long? Currenciesid { get; set; }
        public int? IsActive { get; set; }
        public int? IsDeleted { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual TabCurrencies Currencies { get; set; }
        public virtual ICollection<TabDriverWallet> TabDriverWallet { get; set; }
        public virtual ICollection<TabServicelocation> TabServicelocation { get; set; }
        public virtual ICollection<TabUser> TabUser { get; set; }
    }
}
