using Delegate;

class Program
{
    static void Main()
    {
        List<int> list = new List<int> { 1, 2, 3 };
        var deleg = new Delegate<int>(list);
        Console.WriteLine(deleg);
        deleg.Aggregate2((x, y) => x, 0);
        deleg.Aggregate2((x, y) => y, 0);
        deleg.Aggregate2((x, y) => x * 2 + y * 2, 0);
        deleg.Aggregate2((x, y) => x * 2 + y, 0);
        Console.WriteLine("________________________________\n");

        List<int> q = new List<int> { 1, 2, 3, 4, 1000, 2424, 21, -1,
            3, 100, 51, 28, 46, -19, -28, 76, 0 };
        var dq = new Delegate<int>(q);
        Console.WriteLine(dq);
        dq.Aggregate2((x, y) => Math.Max(x, y), 0);
        dq.Aggregate2((x, y) => Math.Min(x, y), 0);
        Console.WriteLine("________________________________\n");

        List<string> str = new List<string> { "H", "e", "l", "l", "o" };
        var dstr = new Delegate<string>(str);
        Console.WriteLine(dstr);
        dstr.Aggregate2((x, y) => y + x, "");
        dstr.Aggregate2((x, y) => x + y, "");
        Console.WriteLine("________________________________\n");

        var lst = new List<int> { -1, -2, -3, -10, 0, 1, 2, 3, 4, 5, 6, 7, 8 , 10};
        var delegList = new Delegate<int>(lst);
        delegList.Count(x => x > 0);
        delegList.Count(x => x % 2 == 0);
        delegList.Count(x => x % 2 == 1);
        delegList.Count(x => x % 2 != 0 && x > 5);
    }
}

