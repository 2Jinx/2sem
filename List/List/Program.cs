using List;

internal class Program
{
    private static void Main(string[] args)
    {
        try
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
            bigS = fig.HasSquareBiggerThanS(20.0);
            bigS.Show();
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}