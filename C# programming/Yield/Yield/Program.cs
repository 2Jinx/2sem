
using System.ComponentModel;
using Yield;

internal class Program
{
    private static void Main()
    {
        try
        {
            var text = "are how Hi you?";
            WordsInText s = new WordsInText(text);
            foreach (var item in s)
                Console.WriteLine(item);
            Console.WriteLine();

            var text1 = "1 20 300 4000 50000 600000";
            WordsInText s1 = new WordsInText(text1);
            foreach (var c in s1)
                Console.WriteLine(c);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

    }
}

