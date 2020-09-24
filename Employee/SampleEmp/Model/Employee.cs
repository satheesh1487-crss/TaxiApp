using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace SampleEmp 
{
    public class Employee
    {
        [JsonProperty("id")]
        public long Id { set; get; }

        [JsonProperty("firstname")]
        public string Firstname { set; get; }

        [JsonProperty("lastname")]
        public string Lastname { set; get; }

        [JsonProperty("email")]
        public string Email { set; get; }

        [JsonProperty("phoneno")]
        public long Phoneno { set; get; }

        [JsonProperty("dob")]
        public string Dob { set; get; }

        [JsonProperty("age")]
        public int Age { set; get; }

        [JsonProperty("gender")]
        public string Gender { set; get; }
    }
}
