using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxiAppsWebAPICore.Models
{
    public class Dashboard
    {
        [JsonProperty("total_Earnings")]
        public long Total_Earnings { set; get; }

        [JsonProperty("company_Earnings")]
        public long Company_Earnings { set; get; }

        [JsonProperty("driver_Earnings")]
        public long Driver_Earnings { set; get; }

        [JsonProperty("completed_Trips")]
        public long Completed_Trips { set; get; }

        [JsonProperty("on_Going_Trips")]
        public long On_Going_Trips { set; get; }

        [JsonProperty("cancelled_Trips")]
        public long Cancelled_Trips { set; get; }

        [JsonProperty("total_Trips")]
        public long Total_Trips { set; get; }

        [JsonProperty("total_Turnover")]
        public long Total_Turnover { set; get; }

        [JsonProperty("total_Driver_Earnings")]
        public long Total_Driver_Earnings { set; get; }

        [JsonProperty("total_Admin_Earnings")]
        public long Total_Admin_Earnings { set; get; }

        [JsonProperty("payment_Cash")]
        public long Payment_Cash { set; get; }

        [JsonProperty("payment_Cards")]
        public long Payment_Cards { set; get; }

        [JsonProperty("payment_Withdraw")]
        public long Payment_Withdraw { set; get; }

        [JsonProperty("total_Users")]
        public long Total_Users { set; get; }

        [JsonProperty("total_Active_Users")]
        public long Total_Active_Users { set; get; }

        [JsonProperty("total_InActive_Users")]
        public long Total_InActive_Users { set; get; }

        [JsonProperty("total_Deleted_Users")]
        public long Total_Deleted_Users { set; get; }

        [JsonProperty("total_Drivers")]
        public long Total_Drivers { set; get; }

        [JsonProperty("total_Active_Drivers")]
        public long Total_Active_Drivers { set; get; }

        [JsonProperty("total_Approval_Drivers")]
        public long Total_Approval_Drivers { set; get; }

        [JsonProperty("total_Blocked_Drivers")]
        public long Total_Blocked_Drivers { set; get; }


        [JsonProperty("zoneDash")]
        public List<ZoneDash> ZoneDash { set; get; }
    }

    public class ZoneDash
    {
        [JsonProperty("zone_name")]
        public string ZoneName { set; get; }
        [JsonProperty("driver_count")]
        public int DriverCount { set; get; }

        [JsonProperty("total_driver")]
        public int Total_Driver { set; get; }
    }

}
