using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxiAppsWebAPICore 
{
    public class Roles
    {
        private string isActive;
        [JsonProperty("roleID")]
        public long RoleID { get; set; }
        [JsonProperty("roleName")]
        public string  RoleName { get; set; }
        [JsonProperty("DisplayName")]
        public string DisplayName { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("isActive")]
        public  string IsActive { get
            {
                return isActive;
            }
            set
            {
                isActive = value == "1" ? "Active" : "InActive";
            }
        }
        [JsonProperty("status")]
        public string Status { get; set; }
      //  public virtual List<AdminList> AdminLists { get; set; }
    }
    public class Language
    {
        private string isActive;
        [JsonProperty("languageID")]
        public long LanguageID { get; set; }
        [JsonProperty("shortName")]
        public string ShortName { get; set; }
        [JsonProperty("longName")]
        public string LongName { get; set; }
      
        [JsonProperty("isActive")]
        public string IsActive
        {
            get
            {
                return isActive;
            }
            set
            {
                isActive = value == "1" ? "Active" : "InActive";
            }
        }
        [JsonProperty("status")]
        public string LangStatus { get; set; }
        //  public virtual List<AdminList> AdminLists { get; set; }
    }
    public class Country
    {
        private string isActive;
        [JsonProperty("countryID")]
        public long CountryID { get; set; }
        [JsonProperty("code")]
        public string Code { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("contactnocode")]
        public string ContactNoCode { get; set; }
        [JsonProperty("timezone")]
        public string TimeZone { get; set; }
        [JsonProperty("isActive")]
        public string IsActive
        {
            get
            {
                return isActive;
            }
            set
            {
                isActive = value == "1" ? "Active" : "InActive";
            }
        }
        [JsonProperty("status")]
        public string CtryStatus { get; set; }
        //  public virtual List<AdminList> AdminLists { get; set; }
    }


}
