using System;
using System.Collections.Generic;

namespace TaxiAppsWebAPICore.TaxiModels
{
    public partial class TabRefreshtoken
    {
        public long Reftokenid { get; set; }
        public long? Userid { get; set; }
        public string Refreshtoken { get; set; }
        public DateTime? CreatedAt { get; set; }

        public virtual TabAdmin User { get; set; }
    }
}
