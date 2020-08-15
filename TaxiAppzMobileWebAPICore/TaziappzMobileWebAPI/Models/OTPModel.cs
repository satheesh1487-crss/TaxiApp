using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaziappzMobileWebAPI
{
    public class OTPModel
    {
        [JsonProperty("contactno")]
        public long Contactno
        {
            get; set;
        }
        //public long OTP
        //{
        //    get; set;
        //}
        //public DateTime OTPCreatedDate
        //{
        //    get; set;
        //}
        //public DateTime OTPExpiredDate
        //{
        //    get; set;
        //}
        [JsonProperty("devicename")]
        public string DeviceName
        {
            get; set;
        }
        [JsonProperty("deviceIPAddress")]
        public string DeviceIPAddress
        {
            get; set;
        }

    }
    public class ValidateOTPModel
    {
        [JsonProperty("otp")]
        public long OTP
        {
            get; set;
        }
    }
}
