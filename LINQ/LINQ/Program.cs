using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace LINQ;

internal class Program
{
    public static void Main()
    {
        try
        {
            LinqTasks tasks = new LinqTasks();
            //tasks.Task4();

            //tasks.Task16();

            //tasks.Task28();

            //tasks.Task37();

            //tasks.Task40();

            //tasks.Task52();

            //tasks.Task64();

            tasks.Task76();
            
            tasks.Task88();

            tasks.Task100();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
    
}
