using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using System.Xml;
using Task_Management_2._0;

namespace Task_Management_2._0
{
    public class Program
    {
        public static void Main()
        {
            // Создание объектов проекта, клиента, задач и сотрудников
            Customer customer = new Customer
            {
                Name = "ABC Company",
                ContactPerson = "John Doe",
                ContactPhone = "123-456-789",
                ContactEmail = "john.doe@abc.com"
            };

            Employee employee1 = new Employee
            {
                Number = 1,
                FullName = "John Smith",
                Rating = 3,
                Position = new Position
                {
                    Code = "DEV",
                    Name = "Developer",
                    BaseHourlyRate = 300
                }
            };

            Employee employee2 = new Employee
            {
                Number = 2,
                FullName = "Jane Doe",
                Rating = 4,
                Position = new Position
                {
                    Code = "SRDEV",
                    Name = "Senior Developer",
                    BaseHourlyRate = 400
                }
            };

            Task task1 = new Task
            {
                Number = "T1",
                Description = "Task 1 description",
                DueDate = DateTime.Parse("2023-06-01"),
                CloseDate = DateTime.Parse("2023-06-02"),
                HoursSpent = 8,
                Billable = true,
                Responsible = employee1
            };

            Task task2 = new Task
            {
                Number = "T2",
                Description = "Task 2 description",
                DueDate = DateTime.Parse("2023-06-03"),
                CloseDate = DateTime.Parse("2023-06-05"),
                HoursSpent = 12,
                Billable = false,
                Responsible = employee2
            };

            List<Task> tasks = new List<Task> { task1, task2 };

            Project project = new Project
            {
                Key = "P123",
                Title = "Sample Project",
                InitialCost = 1000,
                Customer = customer,
                Tasks = tasks
            };

            // Сериализация и десериализация с использованием JSON
            ISerializationProvider jsonSerializationProvider = new JsonSerializationProvider();
            string jsonFilePath = "project.json";

            jsonSerializationProvider.Serialize(project, jsonFilePath);

            Project deserializedProjectJson = jsonSerializationProvider.Deserialize<Project>(jsonFilePath);

            Console.WriteLine("Deserialized Project (JSON):");
            Console.WriteLine($"Key: {deserializedProjectJson.Key}");
            Console.WriteLine($"Title: {deserializedProjectJson.Title}");
            Console.WriteLine($"InitialCost: {deserializedProjectJson.InitialCost}");
            Console.WriteLine($"Customer Name: {deserializedProjectJson.Customer.Name}");
            Console.WriteLine($"Task Count: {deserializedProjectJson.Tasks.Count}");
            Console.WriteLine($"Total Cost: {deserializedProjectJson.CalculateTotalCost()}");

            // Сериализация и десериализация с использованием XML
            ISerializationProvider xmlSerializationProvider = new XmlSerializationProvider();
            string xmlFilePath = "project.xml";

            xmlSerializationProvider.Serialize(project, xmlFilePath);

            Project deserializedProjectXml = xmlSerializationProvider.Deserialize<Project>(xmlFilePath);

            Console.WriteLine("\nDeserialized Project (XML):");
            Console.WriteLine($"Key: {deserializedProjectXml.Key}");
            Console.WriteLine($"Title: {deserializedProjectXml.Title}");
            Console.WriteLine($"InitialCost: {deserializedProjectXml.InitialCost}");
            Console.WriteLine($"Customer Name: {deserializedProjectXml.Customer.Name}");
            Console.WriteLine($"Task Count: {deserializedProjectXml.Tasks.Count}");
            Console.WriteLine($"Total Cost: {deserializedProjectXml.CalculateTotalCost()}");
        }
    }
}







