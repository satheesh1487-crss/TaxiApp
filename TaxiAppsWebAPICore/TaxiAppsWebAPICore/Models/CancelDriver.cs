﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxiAppsWebAPICore
{
    public class CancelDriver
    {
        [JsonProperty("id")]
        public long Id { get; set; }
        [JsonProperty("cancellationlist")]
        public string CancellationList { get; set; }
        [JsonProperty("payingstatus")]
        public string PayingStatus { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("arrivalstatus")]
        public string ArrivalStatus { get; set; }

        [JsonProperty("isActive")]
        public bool ?IsActive { get; set; }
    }

    public class CancelDriverInfo
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("zoneArea")]
        public long? ZoneArea { get; set; }

        [JsonProperty("paymentstatus")]
        public string PaymentStatus { get; set; }

        [JsonProperty("arrivalstatus")]
        public string ArrivalStatus { get; set; }

        [JsonProperty("cancelReasonEnglish")]
        public string CancelReasonEnglish { get; set; }

        [JsonProperty("cancelReasonArabic")]
        public string CancelReasonArabic { get; set; }

        [JsonProperty("cancelReasonSpanish")]
        public string CancelReasonSpanish { get; set; }
    }
}
