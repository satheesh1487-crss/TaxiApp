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
       [JsonProperty("grandParentMenuname")]
        public string GrandParentMenuname { get; set; }
        [JsonProperty("menuid")]
        public long? Menuid { get; set; }
        [JsonProperty("viewstate")]
        public bool? ViewState { get; set; }
        [JsonProperty("parentMenuhierarchy")]
        public List<ParentMenuhierarchy> parentMenuhierarchies { get; set; }
    }
    public class ParentMenuhierarchy
    {
        [JsonProperty("parentMenuname")]
        public string ParentMenuname { get; set; }
        [JsonProperty("menuid")]
        public long? Menuid { get; set; }
        [JsonProperty("viewstate")]
        public bool? ViewState { get; set; }
        [JsonProperty("childMenuhierarchy")]
        public List<ChildMenuhierarchy> childMenuhierarchies { get; set; }
    }
    public class ChildMenuhierarchy
    {
        [JsonProperty("childMenuname")]
        public string ChildMenuname { get; set; }
        [JsonProperty("menuid")]
        public long? Menuid { get; set; }
        [JsonProperty("viewstate")]
        public bool? ViewState { get; set; }
    }
}
