using System;
using System.Collections.Generic;

namespace TaxiAppsWebAPICore.TaxiModels
{
    public partial class TabRequestPlace
    {
        public long RequestPlaceId { get; set; }
        public decimal? PickLatitude { get; set; }
        public decimal? PickLongitude { get; set; }
        public decimal? DropLatitude { get; set; }
        public decimal? DropLongitude { get; set; }
        public string PickLocation { get; set; }
        public string DropLocation { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDelete { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }
        public long? RequestId { get; set; }

        public virtual TabRequest Request { get; set; }
    }
}
