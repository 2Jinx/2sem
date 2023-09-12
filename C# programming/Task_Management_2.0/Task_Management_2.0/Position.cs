using System;
using Newtonsoft.Json;

namespace Task_Management_2._0
{
    public class Position
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("baseHourlyRate")]
        public decimal BaseHourlyRate { get; set; }
    }
}

