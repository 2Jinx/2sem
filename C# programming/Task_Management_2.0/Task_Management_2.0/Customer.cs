using System;
using Newtonsoft.Json;

namespace Task_Management_2._0
{
    public class Customer
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("contactPerson")]
        public string ContactPerson { get; set; }

        [JsonProperty("contactPhone")]
        public string ContactPhone { get; set; }

        [JsonProperty("contactEmail")]
        public string ContactEmail { get; set; }
    }
}

