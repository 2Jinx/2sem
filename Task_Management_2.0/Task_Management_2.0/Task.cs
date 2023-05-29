using System;
using Newtonsoft.Json;

namespace Task_Management_2._0
{
    public class Task
    {
        [JsonProperty("number")]
        public string Number { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("dueDate")]
        public DateTime DueDate { get; set; }

        [JsonProperty("closeDate")]
        public DateTime CloseDate { get; set; }

        [JsonProperty("hoursSpent")]
        public decimal HoursSpent { get; set; }

        [JsonProperty("billable")]
        public bool Billable { get; set; }

        [JsonProperty("responsible")]
        public Employee Responsible { get; set; }

        public decimal CalculateCost()
        {
            decimal hourlyRate = Responsible.CalculateHourlyRate();
            decimal cost = hourlyRate * HoursSpent;

            if (CloseDate > DueDate)
            {
                decimal penalty = cost * 0.01m;
                decimal maxPenalty = hourlyRate * HoursSpent * 0.25m;
                cost += Math.Min(penalty, maxPenalty);
            }

            return cost;
        }
    }
}

