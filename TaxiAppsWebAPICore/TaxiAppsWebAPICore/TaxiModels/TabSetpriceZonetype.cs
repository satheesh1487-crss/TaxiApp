using System;
using System.Collections.Generic;

namespace TaxiAppsWebAPICore.TaxiModels
{
    public partial class TabSetpriceZonetype
    {
        public long Setpriceid { get; set; }
        public long? Zonetypeid { get; set; }
        public decimal? Baseprice { get; set; }
        public decimal? Pricepertime { get; set; }
        public long Basedistance { get; set; }
        public decimal? Priceperdistance { get; set; }
        public long Freewaitingtime { get; set; }
        public decimal? Waitingcharges { get; set; }
        public decimal? Cancellationfee { get; set; }
        public decimal? Dropfee { get; set; }
        public string Admincommtype { get; set; }
        public decimal? Admincommission { get; set; }
        public decimal? Driversavingper { get; set; }
        public decimal? Customseldrifee { get; set; }
        public string RideType { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDelete { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual TabZonetypeRelationship Zonetype { get; set; }
    }
}
