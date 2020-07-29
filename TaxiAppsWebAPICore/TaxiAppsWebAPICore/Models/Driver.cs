using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxiAppsWebAPICore
{
    public class DriverList
    {
        [JsonProperty("id")]
        public long DriverId { get; set; }

        [JsonProperty("registrationCode")]
        public string RegistrationCode { get; set; }

        [JsonProperty("driverName")]
        public string DriverName { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("phoneNumber")]
        public string PhoneNumber { get; set; }

        [JsonProperty("document")]
        public string Document { get; set; }

        [JsonProperty("rating")]
        public string Rating { get; set; }

        [JsonProperty("acceptanceRatio")]
        public string AcceptanceRatio { get; set; }

        [JsonProperty("isActive")]
        public bool? IsActive { get; set; }     

    }

    public class Driver
    {
        [JsonProperty("operatorName")]
        public string OperatorName { get; set; }

        [JsonProperty("amount")]
        public string Amount { get; set; }

        [JsonProperty("fineReason")]
        public string FineReason { get; set; }

        [JsonProperty("bonusReson")]
        public string BonusReason { get; set; }
    }

    public class DriverInfo
    {
        [JsonProperty("driverid")]
        public long DriverId { get; set; }

        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("contactNo")]
        public string ContactNo { get; set; }

        [JsonProperty("gender")]
        public string Gender { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("country")]
        public long ?Country { get; set; }

        [JsonProperty("driverArea")]
        public long ?DriverArea { get; set; }

        [JsonProperty("company")]
        public string Company { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

        [JsonProperty("driverType")]
        public long ?DriverType { get; set; }

        [JsonProperty("carModel")]
        public string CarModel { get; set; }

        [JsonProperty("carColour")]
        public string CarColour { get; set; }

        [JsonProperty("carNumber")]
        public string CarNumber { get; set; }

        [JsonProperty("carManu")]
        public string CarManu { get; set; }

        [JsonProperty("carYear")]
        public int CarYear { get; set; }

        [JsonProperty("nationalId")]
        public string NationalId { get; set; }

        [JsonProperty("profilePic")]
        public string ProfilePic { get; set; }
    }
}
