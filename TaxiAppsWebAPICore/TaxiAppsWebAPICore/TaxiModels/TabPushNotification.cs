using System;
using System.Collections.Generic;

namespace TaxiAppsWebAPICore.TaxiModels
{
    public partial class TabPushNotification
    {
        public long Pushnotificationid { get; set; }
        public string Messagetitle { get; set; }
        public string Messagesubtitle { get; set; }
        public bool? HasRedirectUrl { get; set; }
        public string MessageDescription { get; set; }
        public string UploadFileName { get; set; }
        public bool? IsDeleted { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
