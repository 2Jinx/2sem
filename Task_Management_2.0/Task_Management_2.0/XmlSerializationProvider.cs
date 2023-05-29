using System;
namespace Task_Management_2._0
{
    public class XmlSerializationProvider : ISerializationProvider
    {
        public void Serialize<T>(T obj, string filePath)
        {
            var serializer = new System.Xml.Serialization.XmlSerializer(typeof(T));

            using (var writer = new StreamWriter(filePath))
            {
                serializer.Serialize(writer, obj);
            }
        }

        public T Deserialize<T>(string filePath)
        {
            var serializer = new System.Xml.Serialization.XmlSerializer(typeof(T));

            using (var reader = new StreamReader(filePath))
            {
                return (T)serializer.Deserialize(reader);
            }
        }
    }
}

