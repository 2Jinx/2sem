using List;

internal class Program
{
    private static void Main(string[] args)
    {
        try
        {
            CircularList();
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    static void Graph()
    {
        Console.WriteLine("read from file...\n");
        GraphicPic figure = new GraphicPic("figures.txt");
        Figure f = new Figure(1, 1, 10.5, 16.6, 0, 3);
        figure.Insert(f);
        figure.Show();
        Console.WriteLine("\nafter delete operation...\n");
        figure.Delete(1); //remove all figures with 1 figure code
        figure.Show();
        Console.WriteLine("\ncommon with...\n");
        GraphicPic fig = new GraphicPic();
        fig = figure.CommonWith(f);
        fig.Show();
        Console.WriteLine("\nbigger square than...\n");
        GraphicPic bigS = new GraphicPic();
        bigS = fig.HasSquareBiggerThanS(2);
        bigS.Show();
    }

    static void CircularList()
    {
        CircularLinkedList<int> list = new CircularLinkedList<int>();
        list.AddFirst(1);
        list.AddLast(2);
        list.AddLast(3);
        list.AddLast(4);
        list.AddLast(5);
        list.AddLast(6);
        Console.WriteLine(list);
        list.ShiftRight(4);
        Console.WriteLine(list.Contains(20));
        Console.WriteLine(list);
        list.GetElement(15);
    }
}