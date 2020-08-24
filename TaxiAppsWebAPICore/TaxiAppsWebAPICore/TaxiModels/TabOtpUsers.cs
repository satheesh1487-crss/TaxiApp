using System;
using System.Collections.Generic;

namespace TaxiAppsWebAPICore.TaxiModels
{
    public partial class TabOtpUsers
    {
        public long Userotpid { get; set; }
        public long UserContactNo { get; set; }
        public int UserOtp { get; set; }
        public DateTime? UserOtpCreatedDate { get; set; }
        public DateTime? UserOtpExpireDate { get; set; }
        public string UserDeviceName { get; set; }
        public string UserDeviceIpaddress { get; set; }
        public bool? IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
