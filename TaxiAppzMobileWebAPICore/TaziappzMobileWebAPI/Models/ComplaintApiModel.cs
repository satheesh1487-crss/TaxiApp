using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaziappzMobileWebAPI.Models
{
    public class ComplaintApiModel
    {
        [JsonProperty("complaint_list")]
        public Complaint_List Complaint_List { get; set; }

        [JsonProperty("admin_key")]
        public string Admin_key { get; set; }
    }
    public class Complaint_List
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }
    }
    public class GeneralComplainModel
    {

    }
    public class RequestComplainModel
    {

    }
}
