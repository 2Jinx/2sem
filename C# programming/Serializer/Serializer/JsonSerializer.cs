using System;
using System.Text;

namespace Serializer
{
    public class JsonSerializer
    {
        public int MyInt { get; set; }
        public string MyString { get; set; }
        public List<int> MyList { get; set; }

        public string SerializeToJson()
        {
            StringBuilder jsonBuilder = new StringBuilder();
            jsonBuilder.Append("{");
            jsonBuilder.AppendFormat("\"MyInt\":{0},", MyInt);
            jsonBuilder.AppendFormat("\"MyString\":\"{0}\",", EscapeString(MyString));
            jsonBuilder.Append("\"MyList\":[");
            if (MyList != null)
            {
                for (int i = 0; i < MyList.Count; i++)
                {
                    jsonBuilder.Append(MyList[i]);
                    if (i < MyList.Count - 1)
                    {
                        jsonBuilder.Append(",");
                    }
                }
            }
            jsonBuilder.Append("]");
            jsonBuilder.Append("}");
            return jsonBuilder.ToString();
        }

        public static JsonSerializer DeserializeFromJson(string json)
        {
            JsonSerializer myObject = new JsonSerializer();
            int currentIndex = 0;

            // Проверка, что JSON-строка начинается с открывающей фигурной скобки
            if (json[currentIndex] != '{')
            {
                throw new Exception("Invalid JSON format. Expected '{' at the beginning.");
            }

            currentIndex++;

            while (currentIndex < json.Length)
            {
                // Поиск следующего ключа
                int keyStartIndex = json.IndexOf("\"", currentIndex);
                int keyEndIndex = json.IndexOf("\"", keyStartIndex + 1);
                if (keyStartIndex == -1 || keyEndIndex == -1)
                {
                    throw new Exception("Invalid JSON format. Key not found.");
                }

                string key = json.Substring(keyStartIndex + 1, keyEndIndex - keyStartIndex - 1);

                // Поиск значения
                int valueStartIndex = json.IndexOf(":", keyEndIndex + 1);
                if (valueStartIndex == -1)
                {
                    throw new Exception("Invalid JSON format. Value not found.");
                }

                currentIndex = valueStartIndex + 1;

                // Обработка значений в зависимости от ключа
                if (key == "MyInt")
                {
                    int valueEndIndex = json.IndexOf(",", currentIndex);
                    if (valueEndIndex == -1)
                    {
                        valueEndIndex = json.IndexOf("}", currentIndex);
                    }

                    int value = int.Parse(json.Substring(currentIndex, valueEndIndex - currentIndex));
                    myObject.MyInt = value;

                    currentIndex = valueEndIndex;
                }
                else if (key == "MyString")
                {
                    int valueStartQuoteIndex = json.IndexOf("\"", currentIndex);
                    int valueEndQuoteIndex = json.IndexOf("\"", valueStartQuoteIndex + 1);
                    if (valueStartQuoteIndex == -1 || valueEndQuoteIndex == -1)
                    {
                        throw new Exception("Invalid JSON format. String value not found.");
                    }

                    string value = UnescapeString(json.Substring(valueStartQuoteIndex + 1, valueEndQuoteIndex - valueStartQuoteIndex - 1));
                    myObject.MyString = value;

                    currentIndex = valueEndQuoteIndex + 1;
                }
                else if (key == "MyList")
                {
                    int arrayStartIndex = json.IndexOf("[", currentIndex);
                    int arrayEndIndex = json.IndexOf("]", arrayStartIndex + 1);
                    if (arrayStartIndex == -1 || arrayEndIndex == -1)
                    {
                        throw new Exception("Invalid JSON format. Array value not found.");
                    }

                    string arrayValue = json.Substring(arrayStartIndex + 1, arrayEndIndex - arrayStartIndex - 1);

                    if (!string.IsNullOrWhiteSpace(arrayValue))
                    {
                        string[] values = arrayValue.Split(',');

                        List<int> list = new List<int>();
                        foreach (string value in values)
                        {
                            list.Add(int.Parse(value));
                        }

                        myObject.MyList = list;
                    }

                    currentIndex = arrayEndIndex + 1;
                }

                // Поиск следующей запятой или закрывающей фигурной скобки
                int nextSeparatorIndex = json.IndexOfAny(new[] { ',', '}' }, currentIndex);
                if (nextSeparatorIndex == -1)
                {
                    break;
                }

                currentIndex = nextSeparatorIndex + 1;
            }

            return myObject;
        }

        private static string EscapeString(string value)
        {
            return value.Replace("\\", "\\\\").Replace("\"", "\\\"");
        }

        private static string UnescapeString(string value)
        {
            return value.Replace("\\\"", "\"").Replace("\\\\", "\\");
        }
    }
}

