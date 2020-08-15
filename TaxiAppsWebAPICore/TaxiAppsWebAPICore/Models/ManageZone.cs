using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxiAppsWebAPICore.Models;
using TaxiAppsWebAPICore.TaxiModels;

namespace TaxiAppsWebAPICore 
{
    public class ManageZone
    {
        [JsonProperty("zoneid")]
        public long Zoneid { get; set; }
        [JsonProperty("zoneName")]
        public string ZoneName { get; set; }
        [JsonProperty("unit")]
        public string Unit { get; set; }

        [JsonProperty("serviceName")]
        public string ServiceName { get; set; }
        [JsonProperty("isActive")]
        public bool IsActive { get; set; }
        [JsonProperty("serviceslocid")]
        public long? Serviceslocid { get; set; }
        [JsonProperty("zonepolygonlist")]
        public List<ManageZonePolygon> ZonePolygoneList { get; set; }



    }
    public class ManageZoneAdd
    {
        [JsonProperty("zoneid")]
        public long Zoneid { get; set; }
        [JsonProperty("zoneName")]
        public string ZoneName { get; set; }
       
        [JsonProperty("unit")]
        public string Unit { get; set; }
        //[JsonProperty("isDeleted")]
        //public int isDeleted { get; set; }
        //[JsonProperty("updatedby")]
        //public string UpdatedBy { get; set; }
        ////[JsonProperty("updateddate")]
        ////public DateTime UpdatedDate { get; set; }
        //[JsonProperty("deletedby")]
        //public string DeletedBy { get; set; }
        ////[JsonProperty("deleteddate")]
        ////public DateTime DeletedDate { get; set; }
        //[JsonProperty("createdby")]
        //public string CreatedBy { get; set; }
        //[JsonProperty("servicesloclist")]
        //public ServiceListModel ServicesLocationList { get; set; }
        [JsonProperty("serviceslocid")]
        public long? Serviceslocid { get; set; }
        [JsonProperty("zonePolygoneList")]
        public List<ManageZonePolygon> ZonePolygoneList { get; set; }



    }
    public class ManageZonePolygon
    {
        [JsonProperty("zonepolygonid")]
        public long Zonepolygonid { get; set; }
        //[JsonProperty("zoneid")]
        //public long Zoneid { get; set; }
        [JsonProperty("lat")]
        public decimal? Lat { get; set; }
        [JsonProperty("lng")]
        public decimal? Lng { get; set; }
     
        

    }
}
