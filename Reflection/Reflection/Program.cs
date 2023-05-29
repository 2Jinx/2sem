using System;
using System.Reflection;

// Базовый класс или интерфейс
public class MyBaseClass
{
    public void MyMethod()
    {
        Console.WriteLine("Метод базового класса");
    }
}

// Класс, наследующий базовый класс и имеющий статические члены
public class MyClass : MyBaseClass
{
    private int privateField;
    public string PublicField;

    private int PrivateProperty { get; set; }
    public string PublicProperty { get; set; }

    private static int privateStaticField;
    public static string publicStaticField;

    private static int PrivateStaticProperty { get; set; }
    public static string PublicStaticProperty { get; set; }

    private void PrivateMethod()
    {
        Console.WriteLine("Приватный метод");
    }

    public void PublicMethod()
    {
        Console.WriteLine("Публичный метод");
    }

    private static void PrivateStaticMethod()
    {
        Console.WriteLine("Приватный статический метод");
    }

    public static void PublicStaticMethod()
    {
        Console.WriteLine("Публичный статический метод");
    }

    public void PrintAllFields()
    {
        FieldInfo[] fields = typeof(MyClass).GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

        Console.WriteLine("--- Поля после изменения ---");
        foreach (var field in fields)
        {
            var value = field.GetValue(this);
            Console.WriteLine($"{field.Name}: {value}");
        }
    }
}

public class Program
{
    public static void Main()
    {
        // Создание объекта с использованием рефлексии
        Type myClassType = typeof(MyClass);
        object myClassInstance = Activator.CreateInstance(myClassType);

        // Получение и изменение полей
        FieldInfo privateFieldInfo = myClassType.GetField("privateField", BindingFlags.Instance | BindingFlags.NonPublic);
        privateFieldInfo.SetValue(myClassInstance, 10);

        FieldInfo publicFieldInfo = myClassType.GetField("PublicField", BindingFlags.Instance | BindingFlags.Public);
        publicFieldInfo.SetValue(myClassInstance, "Hello");

        // Получение и изменение свойств
        PropertyInfo privatePropertyInfo = myClassType.GetProperty("PrivateProperty", BindingFlags.Instance | BindingFlags.NonPublic);
        privatePropertyInfo.SetValue(myClassInstance, 20);

        PropertyInfo publicPropertyInfo = myClassType.GetProperty("PublicProperty", BindingFlags.Instance | BindingFlags.Public);
        publicPropertyInfo.SetValue(myClassInstance, "World");

        // Вызов методов
        MethodInfo privateMethodInfo = myClassType.GetMethod("PrivateMethod", BindingFlags.Instance | BindingFlags.NonPublic);
        privateMethodInfo.Invoke(myClassInstance, null);

        MethodInfo publicMethodInfo = myClassType.GetMethod("PublicMethod", BindingFlags.Instance | BindingFlags.Public);
        publicMethodInfo.Invoke(myClassInstance, null);

        // Получение и изменение статических полей
        FieldInfo privateStaticFieldInfo = myClassType.GetField("privateStaticField", BindingFlags.Static | BindingFlags.NonPublic);
        privateStaticFieldInfo.SetValue(null, 30);

        FieldInfo publicStaticFieldInfo = myClassType.GetField("publicStaticField", BindingFlags.Static | BindingFlags.Public);
        publicStaticFieldInfo.SetValue(null, "Static Hello");

        // Получение и изменение статических свойств
        PropertyInfo privateStaticPropertyInfo = myClassType.GetProperty("PrivateStaticProperty", BindingFlags.Static | BindingFlags.NonPublic);
        privateStaticPropertyInfo.SetValue(null, 40);

        PropertyInfo publicStaticPropertyInfo = myClassType.GetProperty("PublicStaticProperty", BindingFlags.Static | BindingFlags.Public);
        publicStaticPropertyInfo.SetValue(null, "Static World");

        // Вызов статических методов
        MethodInfo privateStaticMethodInfo = myClassType.GetMethod("PrivateStaticMethod", BindingFlags.Static | BindingFlags.NonPublic);
        privateStaticMethodInfo.Invoke(null, null);

        MethodInfo publicStaticMethodInfo = myClassType.GetMethod("PublicStaticMethod", BindingFlags.Static | BindingFlags.Public);
        publicStaticMethodInfo.Invoke(null, null);

        // Вывод всех полей до и после изменения
        MyClass myObject = (MyClass)myClassInstance;
        myObject.PrintAllFields();
    }
}
