using System;
using System.Collections.Generic;

namespace TaxiAppsWebAPICore.TaxiModels
{
    public partial class TabCountries
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string FullName { get; set; }
        public string Capital { get; set; }
        public string Citizenship { get; set; }
        public string Currency { get; set; }
        public string CurrencyCode { get; set; }
        public string CurrencySubUnit { get; set; }
        public string CurrencySymbol { get; set; }
        public string CountryCode { get; set; }
        public string RegionCode { get; set; }
        public string SubRegionCode { get; set; }
        public int Eea { get; set; }
        public string CallingCode { get; set; }
        public string Iso31662 { get; set; }
        public string Iso31663 { get; set; }
        public decimal CurrencyDecimals { get; set; }
        public string Flag { get; set; }
        public int Active { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
