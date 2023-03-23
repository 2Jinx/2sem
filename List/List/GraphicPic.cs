using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using List;
namespace List
{
    public class Figure // вся информация о фигуре
    {
        protected double upper_bound_X { get; set; } // левая верхняя вершина по оХ
        protected double lower_bound_X { get; set; } // правая нижняя вершина по оХ
        protected double upper_bound_Y { get; set; } // левая верхняя вершина по оУ
        protected double lower_bound_Y { get; set; } // правая нижняя вершина по оУ
        protected int colour_code { get; set; }     // код цвета фигуры
        protected int figure_code { get; set; }     // код фигуры

        public Figure(int f_code, int c_code, double up_x, double up_y, double l_x, double l_y)
        {
            if (f_code > 0 && f_code <= 3)
            {
                figure_code = f_code;
                colour_code = c_code;
                upper_bound_X = up_x;
                upper_bound_Y = up_y;
                lower_bound_X = l_x;
                lower_bound_Y = l_y;
            }
            else
            {
                throw new ArgumentException("this type of figure is not expected");
            }
        }

        public double[] Vertices
        {
            get
            {
                double[] vert = new double[4];
                vert[0] = upper_bound_X;
                vert[1] = lower_bound_X;
                vert[2] = upper_bound_Y;
                vert[3] = lower_bound_Y;
                return vert;
            }
        }
        public int FigureType
        {
            get
            {
                return figure_code;
            }
            set
            {
                figure_code = value;
            }
        }

        public double Square
        {
            get
            {
                if (FigureType == 1)
                {
                    return Math.Abs(upper_bound_X - lower_bound_X) * Math.Abs(upper_bound_Y - lower_bound_Y);
                }
                else if (FigureType == 3)
                {
                    return Math.PI * Math.Abs(Math.Sqrt((upper_bound_X - lower_bound_X) * (upper_bound_X - lower_bound_X)
                         + ((upper_bound_Y - lower_bound_Y) * (upper_bound_Y - lower_bound_Y))));
                }
                return 0;
            }
        }

        public bool CommonWith(Figure a, Figure b)
        {
            if ((a.upper_bound_X == b.upper_bound_X && a.upper_bound_Y == b.upper_bound_Y) ||
                (a.lower_bound_X == b.lower_bound_X && a.lower_bound_Y == b.lower_bound_Y))
                return true;
            return false;
        }

        public bool HasBiggerSquareThanS(Figure a, double s)
        {
            if (a.FigureType != 2)
            {
                if (a.Square > s)
                    return true;
                return false;
            }
            return false;
        }
        public override string ToString()
        {
            var sb = new StringBuilder();
            if (figure_code == 1)
            {
                sb.Append($"Фигура - прямоугольник, координаты левой " +
                    $"верхней вершины - ({upper_bound_X},{upper_bound_Y}), " +
                    $"координаты нижней правой вершины - ({lower_bound_X},{lower_bound_Y}), " +
                    $"код цвета фигуры - {colour_code}");
            }
            if (figure_code == 2)
            {
                sb.Append($"Фигура - отрезок, координаты " +
                    $"верхней вершины - ({upper_bound_X},{upper_bound_Y}), " +
                    $"координаты нижней вершины - ({lower_bound_X},{lower_bound_Y}), " +
                    $"код цвета фигуры - {colour_code}");
            }
            if (figure_code == 3)
            {
                sb.Append($"Фигура - круг, координаты " +
                    $"центра - ({upper_bound_X},{upper_bound_Y}), " +
                    $"координаты радиуса - ({lower_bound_X},{lower_bound_Y}), " +
                    $"код цвета фигуры - {colour_code}");
            }
            return sb.ToString();
        }
    }

    public class GraphicPic
    {
        protected List<Figure> figures = new List<Figure>();

        public GraphicPic(string filename)
        {
            using (StreamReader reader = new StreamReader(filename))
            {
                while (reader.Peek() != -1)
                {
                    string[] str = reader.ReadLine().Split(' ');
                    figures.Add(new Figure(int.Parse(str[0]), int.Parse(str[1]),
                        double.Parse(str[2]), double.Parse(str[3]),
                        double.Parse(str[4]), double.Parse(str[5])));
                }
            }
        }

        public GraphicPic(List<Figure> k)
        {
            figures = k;
        }

        public GraphicPic()
        {

        }

        public GraphicPic CommonWith(Figure r)
        {
            if (r.FigureType != 1)
                throw new ArgumentException("please, insert correct figure!");
            List<Figure> newFigures = new List<Figure>();
            foreach (var f in figures)
            {
                if (f.CommonWith(f, r))
                {
                    newFigures.Add(f);
                }
            }
            GraphicPic newF = new GraphicPic(newFigures); 
            return newF;
        }

        public GraphicPic HasSquareBiggerThanS(double s)
        {
            if (s <= 0)
                throw new ArgumentException("please, insert the correct square num!");
            List<Figure> biggerSq = new List<Figure>();
            foreach (var f in figures)
            {
                if (f.HasBiggerSquareThanS(f, s))
                {
                    biggerSq.Add(f);
                }
            }
            GraphicPic bigSq = new GraphicPic(biggerSq);
            return bigSq;
        }

        public void Show()
        {
            foreach(var f in figures)
            {
                Console.WriteLine(f);
            }
        }

        public void Delete(int i)
        {
            foreach (var f in figures.Where(x => x.FigureType == i).ToList())
            {
                figures.Remove(f);
            }
        }

        public void Insert(Figure f)
        {
            figures.Add(f);
        }
    }
}

