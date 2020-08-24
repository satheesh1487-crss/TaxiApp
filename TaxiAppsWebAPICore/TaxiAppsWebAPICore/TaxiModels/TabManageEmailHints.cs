using System;
using System.Collections.Generic;

namespace TaxiAppsWebAPICore.TaxiModels
{
    public partial class TabManageEmailHints
    {
        public long ManageEmailHint { get; set; }
        public long? ManageEmailid { get; set; }
        public string HintKeyword { get; set; }
        public string HintDescription { get; set; }

        public virtual TabManageEmail ManageEmail { get; set; }
    }
}
