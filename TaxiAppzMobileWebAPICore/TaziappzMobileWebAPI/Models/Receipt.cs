﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace TaziappzMobileWebAPI 
{
    public class Receipt
    {
       [JsonProperty("baseprice")]
       public double Baseprice { get; set; }
    }
}
