using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxiAppsWebAPICore.Models
{
    public class TripSettings
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("tripSettingQuestion")]
        public string TripSettingQuestion { get; set; }

        [JsonProperty("TripSettingAnswer")]
        public string TripSettingAnswer { get; set; }

        [JsonProperty("assignMethod")]
        public string AssignMethod { get; set; }

        [JsonProperty("requestWaitSecond")]
        public string RequestWaitSecond { get; set; }

        [JsonProperty("requestInKm")]
        public string RequestInKm { get; set; }

        [JsonProperty("transferTripAmount")]
        public string TransferTripAmount { get; set; }

        [JsonProperty("pickupLocationUnits")]
        public string PickupLocationUnits { get; set; }

        [JsonProperty("captainGetTrips")]
        public string CaptainGetTrips { get; set; }

        [JsonProperty("locationChangeLimit")]
        public string LocationChangeLimit { get; set; }

        [JsonProperty("captainsRatingLimit")]
        public string CaptainsRatingLimit { get; set; }

        [JsonProperty("tripGraceTime")]
        public string TripGraceTime { get; set; }

        [JsonProperty("scheduleTripsTime")]
        public string ScheduleTripsTime { get; set; }

        [JsonProperty("dispatchRequest")]
        public string DispatchRequest { get; set; }

        [JsonProperty("CertainMinutes")]
        public string CertainMinutes { get; set; }

        [JsonProperty("rewardPoints")]
        public string RewardPoints { get; set; }
    }
}
