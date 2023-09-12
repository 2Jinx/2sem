using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Serializer
{
    public class Program
    {
        public static void Main()
        {
            // Создание объекта для сериализации
            JsonSerializer myObject = new JsonSerializer
            {
                MyInt = 123,
                MyString = "Hello World",
                MyList = new List<int> { 1, 2, 3, 4, 5 }
            };

            // Сериализация в JSON
            string json = myObject.SerializeToJson();
            Console.WriteLine(json);

            // Запись JSON в файл
            string filePath = "output.json";
            File.WriteAllText(filePath, json);

            // Чтение JSON из файла
            string jsonFromFile = File.ReadAllText(filePath);

            // Десериализация из JSON
            JsonSerializer deserializedObject = JsonSerializer.DeserializeFromJson(jsonFromFile);

            // Вывод данных
            Console.WriteLine("Deserialized Object:");
            Console.WriteLine("MyInt: " + deserializedObject.MyInt);
            Console.WriteLine("MyString: " + deserializedObject.MyString);
            Console.WriteLine("MyList: ");
            foreach (int value in deserializedObject.MyList)
            {
                Console.WriteLine(value);
            }
        }
    }
}


