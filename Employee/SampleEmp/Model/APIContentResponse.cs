﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleEmp
{
    public class APIContentResponse<T> : APIResponse
    {
        [JsonProperty("content")]
        public T Content { get; set; }
        [JsonProperty("contentList")]
        public List<T> ContentList { get; set; }
    }
}
