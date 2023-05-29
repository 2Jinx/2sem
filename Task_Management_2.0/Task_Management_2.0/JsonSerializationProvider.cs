using System;
using Newtonsoft.Json;

namespace Task_Management_2._0
{
    public class JsonSerializationProvider : ISerializationProvider
    {
        public void Serialize<T>(T obj, string filePath)
        {
            string json = JsonConvert.SerializeObject(obj, Formatting.Indented);
            File.WriteAllText(filePath, json);
        }

        public T Deserialize<T>(string filePath)
        {
            string json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}

