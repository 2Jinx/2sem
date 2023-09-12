using Stack;

namespace Stack;

public class Program
{
    public static void Main()
    {
        try
        {
            //// 1
            //string bracketsStr = "([()])";
            //string bracketsStr1 = "{([()])";
            //string bracketsStr2 = "{([()])}";

            //void BracketsCheck(string str)
            //{
            //    MyStack<char> brackets = new MyStack<char>(str.Length);
            //    if (str.Length % 2 == 1)
            //        Console.WriteLine("wrong bracket notation!");
            //    for (int i = 0; i < str.Length; i++)
            //    {
            //        if (str[i] == '{' || str[i] == '(' || str[i] == '[')
            //            brackets.Push(str[i]);
            //        else if (str[i] == '}' && brackets.Peek() == '{')
            //            brackets.Pop();
            //        else if (str[i] == ')' && brackets.Peek() == '(')
            //            brackets.Pop();
            //        else if (str[i] == ']' && brackets.Peek() == '[')
            //            brackets.Pop();
            //    }

            //    if (brackets.Length == 0)
            //        Console.WriteLine("correct bracket notation!");
            //    else
            //    {
            //        Console.WriteLine("wrong bracket notation!");
            //    }
            //}
            //Console.WriteLine("---> 1 task <---");
            //BracketsCheck(bracketsStr);
            ////BracketsCheck(bracketsStr1);
            ////BracketsCheck(bracketsStr2);
            //Console.WriteLine();

            ////2
            //Console.WriteLine("---> 2 task <---");
            //int n = 10;
            //MyQueue<int> queue = new MyQueue<int>(n);
            //int[] numbers = new int[n];
            //Random r = new Random();
            //for (int i = 0; i < n; i++)
            //    numbers[i] = r.Next(-100, 100);
            //for (int i = 0; i < n; i++)
            //{
            //    if (numbers[i] >= 0)
            //        queue.Enqueue(numbers[i]);
            //    else
            //        Console.Write($" {numbers[i]} ");
            //}
            //Console.WriteLine($" || {queue}");
            //Console.WriteLine();

            //3
            Console.WriteLine("---> 3 task <---");
            Random r = new Random();
            MyStack<int> stack = new MyStack<int>(10);
            FindMaxInStack stack1 = new FindMaxInStack(10);
            for (int i = 0; i < 10; i++)
            {
                stack.Push(r.Next(-100, 100));
                stack1.Push(stack.Peek());
            }
            Console.WriteLine(stack);
            Console.WriteLine();
            Console.WriteLine($"trueMax = {stack.TrueMax()}");
            Console.WriteLine();
            Console.WriteLine(stack1);
            Console.WriteLine();
            Console.WriteLine($"Max = {stack1.GetMax()}");

            //MyStack<int> stack = new MyStack<int>(1);

            //stack.Push(1);
            //Console.WriteLine(stack);
            //stack.Push(2);
            //Console.WriteLine(stack);
            //stack.Push(3);
            //Console.WriteLine(stack);
            //stack.Push(4);
            //Console.WriteLine(stack);

            //Console.WriteLine();
            //MyQueue<int> queue = new MyQueue<int>(1);

            //queue.Enqueue(1);
            //Console.WriteLine(queue);
            //queue.Enqueue(2);
            //Console.WriteLine(queue);
            //queue.Enqueue(3);
            //Console.WriteLine(queue);
            //queue.Enqueue(4);
            //Console.WriteLine(queue);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        
    }
}
