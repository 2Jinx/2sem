using System;
namespace Task_Management_2._0
{
    public interface ISerializationProvider
    {
        void Serialize<T>(T obj, string filePath);
        T Deserialize<T>(string filePath);
    }
}

