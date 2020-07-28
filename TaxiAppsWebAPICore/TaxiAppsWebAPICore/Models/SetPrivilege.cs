using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxiAppsWebAPICore 
{
    public class Menus
    {
       [JsonProperty("menuid")]
       public long? Menuid { get; set; }
        [JsonProperty("menuname")]
        public string MenuName { get; set; }
        [JsonProperty("parentid")]
        public long? ParentId { get; set; }

    }
    public class GrandParentMenuhierarchy
    {
       [JsonProperty("name")]
        public string GrandParentMenuname { get; set; }
        [JsonProperty("menuid")]
        public long? Menuid { get; set; }
        [JsonProperty("viewstate")]
        public bool? ViewState { get; set; }
        [JsonProperty("children")]
        public List<ParentMenuhierarchy> parentMenuhierarchies { get; set; }
    }
    public class ParentMenuhierarchy
    {
        [JsonProperty("name")]
        public string ParentMenuname { get; set; }
        [JsonProperty("menuid")]
        public long? Menuid { get; set; }
        [JsonProperty("viewstate")]
        public bool? ViewState { get; set; }
        [JsonProperty("children")]
        public List<ChildMenuhierarchy> childMenuhierarchies { get; set; }
    }
    public class ChildMenuhierarchy
    {
        [JsonProperty("name")]
        public string ChildMenuname { get; set; }
        [JsonProperty("menuid")]
        public long? Menuid { get; set; }
        [JsonProperty("viewstate")]
        public bool? ViewState { get; set; }
    }
}
