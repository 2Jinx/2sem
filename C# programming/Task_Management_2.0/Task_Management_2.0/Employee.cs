using System;
using Newtonsoft.Json;

namespace Task_Management_2._0
{
    public class Employee
    {
        [JsonProperty("number")]
        public int Number { get; set; }

        [JsonProperty("fullName")]
        public string FullName { get; set; }

        [JsonProperty("rating")]
        public int Rating { get; set; }

        [JsonProperty("position")]
        public Position Position { get; set; }

        public decimal CalculateHourlyRate()
        {
            decimal baseHourlyRate = Position.BaseHourlyRate;
            decimal incrementRate = baseHourlyRate * (Rating - 1) * 0.05m;
            return baseHourlyRate + incrementRate;
        }
    }
}

