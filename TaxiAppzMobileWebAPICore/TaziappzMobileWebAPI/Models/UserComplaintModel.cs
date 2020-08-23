using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaziappzMobileWebAPI.Models
{
    public class ComplaintListModel
    {
        [JsonProperty("complaint_list")]
        public List<User_Complaint_List> Complaint_List { get; set; }

        [JsonProperty("admin_key")]
        public string Admin_Key { get; set; }
    }
    public class User_Complaint_List
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }
    }
    public class UserDisputeModel
    {

    }
    public class UserComplaintsAddModel
    {

    }
}

