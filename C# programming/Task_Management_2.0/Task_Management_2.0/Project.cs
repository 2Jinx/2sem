using System;
using Newtonsoft.Json;

namespace Task_Management_2._0
{
    public class Project
    {
        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("initialCost")]
        public decimal InitialCost { get; set; }

        [JsonProperty("customer")]
        public Customer Customer { get; set; }

        [JsonProperty("tasks")]
        public List<Task> Tasks { get; set; }

        public decimal CalculateTotalCost()
        {
            decimal totalCost = InitialCost;

            foreach (Task task in Tasks)
            {
                decimal taskCost = task.CalculateCost();
                totalCost += taskCost;
            }

            return totalCost;
        }
    }
}

