using System.Linq;
using System.Text.RegularExpressions;

namespace LINQ;

internal class Program
{
    public static void Main()
    {
        try
        {
            //Console.WriteLine("Задание 4...\n");
            //Task4();
            //Console.WriteLine("\nЗадание 16...\n");
            //Task16();
            //Console.WriteLine("\n\nЗадание 28...\n");
            //Task28();
            //Console.WriteLine("\n\nЗадание 37...\n");
            //Task37();
            //Console.WriteLine("\n\nЗадание 40...\n");
            //Task40();
            Console.WriteLine("\n\nЗадание 52...\n");
            Task52();
            Console.WriteLine("\n\nЗадание 64...\n");
            Task64();
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public static void Task4()
    {
        var clients = new List<Client>()
        {
            new Client { Code = 1, WorkingHours = 10, Month = 1, Year = 2004 },
            new Client { Code = 1, WorkingHours = 20, Month = 3, Year = 2004 },
            new Client { Code = 3, WorkingHours = 10, Month = 4, Year = 2005 },
            new Client { Code = 2, WorkingHours = 20, Month = 4, Year = 2005 },
            new Client { Code = 3, WorkingHours = 1, Month = 5, Year = 2002 },
        };

        var year = clients.GroupBy(x => x.Code).Select(x => new
        {
            Time = x.Sum(x => x.WorkingHours),
            Code = x.Key
        });

        foreach (var item in year.OrderBy(x => x.Code).ThenBy(x => -x.Time))
        {
            Console.WriteLine($"{item.Code}, {item.Time}");
        }
    }

    public static void Task16()
    {
        var abiturients = new List<Abiturient>
        {
            new Abiturient{Year = 2003, Surname = "Иванов", SchoolNumber = 18},
            new Abiturient{Year = 2001, Surname = "Петров", SchoolNumber = 32},
            new Abiturient{Year = 2000, Surname = "Сидоров", SchoolNumber = 61},
            new Abiturient{Year = 2002, Surname = "Смиронов", SchoolNumber = 11},
            new Abiturient{Year = 2002, Surname = "Васильев", SchoolNumber = 112},
        };

        var abiturient = abiturients.GroupBy(x => x.Year).Select(x => new
        {
            CountAbiturient = x.Count(),
            Year = x.Key
        });

        foreach (var item in abiturient.OrderBy(x => -x.CountAbiturient).ThenBy(x => x.Year))
        {
            Console.WriteLine($"Абитуриенты: {item.CountAbiturient} | Год: {item.Year}");
        }
    }

    public static void Task28()
    {
        var debtors = new List<Debtor>
        {
            new Debtor{Surname = "Иванов", FlatNumber = 1, Duty = 10.25},
            new Debtor{Surname = "Петров", FlatNumber = 5, Duty = 0},
            new Debtor{Surname = "Сидоров", FlatNumber = 3, Duty = 11.25},
            new Debtor{Surname = "Смирнов", FlatNumber = 9, Duty = 15.25},
            new Debtor{Surname = "Гагарин", FlatNumber = 2, Duty = 145.32},
            new Debtor{Surname = "Жуков", FlatNumber = 10, Duty = 391.76},
            new Debtor{Surname = "Борисов", FlatNumber = 30, Duty = 150.25},
            new Debtor{Surname = "Дятлов", FlatNumber = 13, Duty = 5025},
            new Debtor{Surname = "Васильев", FlatNumber = 21, Duty = 1225},
            new Debtor{Surname = "Хакимов", FlatNumber = 25, Duty = 1765},
            new Debtor{Surname = "Горшков", FlatNumber = 34, Duty = 15025},
            new Debtor{Surname = "Сахаров", FlatNumber = 2, Duty = 142},
            new Debtor{Surname = "Кузнецов", FlatNumber = 5, Duty = 86},
            new Debtor{Surname = "Попов", FlatNumber = 4, Duty = 0},
            new Debtor{Surname = "Соколов", FlatNumber = 9, Duty = 520.30},
            new Debtor{Surname = "Михайлов", FlatNumber = 7, Duty = 781.65},
            new Debtor{Surname = "Жуков", FlatNumber = 11, Duty = 7284.87},
            new Debtor{Surname = "Рябов", FlatNumber = 31, Duty = 3475.60},
            new Debtor{Surname = "Никитин", FlatNumber = 14, Duty = 942},
            new Debtor{Surname = "Поляков", FlatNumber = 22, Duty = 13735},
            new Debtor{Surname = "Цветков", FlatNumber = 26, Duty = 2624.09},
            new Debtor{Surname = "Федотов", FlatNumber = 33, Duty = 3413.98},
        };

        var debtor = debtors.GroupBy(x => (x.FlatNumber - 1) / 4 + 1).Select(x => new
        {
            Ground = x.Key,
            Count = x.Count(x => x.Duty > 0),
            Cost = x.Where(x => x.Duty >= 0).Sum(x => x.Duty)
        });

        foreach (var d in debtor.OrderBy(x => x.Ground))
        {
            Console.WriteLine($"Кол-во должников: {d.Count} | Этаж: {d.Ground} | Задолжность: {d.Cost:F2}");
        }
    }

    public static void Task37()
    {
        var gasStations = new List<GasStation>
        {
            new GasStation{CostOfOneLiter = 46,BrandOfGasoline = 92, Company = "Татнефть", Street = "Пушкина"},
            new GasStation{CostOfOneLiter = 40,BrandOfGasoline = 98, Company = "Татнефть", Street = "Арбузова"},
            new GasStation{CostOfOneLiter = 60,BrandOfGasoline = 95, Company = "Лукойл", Street = "Кошаева"},
            new GasStation{CostOfOneLiter = 90,BrandOfGasoline = 98, Company = "Ирбис", Street = "Первая парковая"},
            new GasStation{CostOfOneLiter = 30,BrandOfGasoline = 95, Company = "Лукойл", Street = "Московская"},
            new GasStation{CostOfOneLiter = 50,BrandOfGasoline = 92, Company = "Ирбис", Street = "Маяковского"},
        };

        var gas = gasStations.GroupBy(x => x.BrandOfGasoline).Select(x => new
        {
            Station = x.Where(x => x.BrandOfGasoline > 0).Count(),
            Min = x.Where(x => x.BrandOfGasoline > 0).Min(x => x.CostOfOneLiter),
            Max = x.Where(x => x.BrandOfGasoline > 0).Max(x => x.CostOfOneLiter),
            Number = x.Key
        });

        foreach (var g in gas.OrderBy(x => x.Station).ThenBy(x => -x.Number))
        {
            Console.WriteLine($"Марка: {g.Number} | {g.Max} {g.Min}");
        }
    }

    public static void Task40()
    {
        var gasStations = new List<GasStation>
        {
            new GasStation{CostOfOneLiter = 46,BrandOfGasoline = 92, Company = "Татнефть", Street = "Пушкина"},
            new GasStation{CostOfOneLiter = 67,BrandOfGasoline = 98, Company = "Татнефть", Street = "Арбузова"},
            new GasStation{CostOfOneLiter = 60,BrandOfGasoline = 95, Company = "Лукойл", Street = "Кошаева"},
            new GasStation{CostOfOneLiter = 90,BrandOfGasoline = 98, Company = "Ирбис", Street = "Парковая"},
            new GasStation{CostOfOneLiter = 30,BrandOfGasoline = 95, Company = "Лукойл", Street = "Московская"},
            new GasStation{CostOfOneLiter = 50,BrandOfGasoline = 92, Company = "Ирбис", Street = "Маяковского"},
            new GasStation{CostOfOneLiter = 46,BrandOfGasoline = 92, Company = "Татнефть", Street = "Огарева"},
            new GasStation{CostOfOneLiter = 40,BrandOfGasoline = 95, Company = "Лукойл", Street = "Арбузова"},
            new GasStation{CostOfOneLiter = 60,BrandOfGasoline = 95, Company = "ТаифНК", Street = "Кошаева"},
            new GasStation{CostOfOneLiter = 42,BrandOfGasoline = 92, Company = "Ирбис", Street = "Васильева"},
            new GasStation{CostOfOneLiter = 67,BrandOfGasoline = 98, Company = "Лукойл", Street = "Московская"},
            new GasStation{CostOfOneLiter = 50,BrandOfGasoline = 92, Company = "Ирбис", Street = "Маяковского"},
            new GasStation{CostOfOneLiter = 46,BrandOfGasoline = 92, Company = "Татнефть", Street = "Пушкина"},
            new GasStation{CostOfOneLiter = 58,BrandOfGasoline = 98, Company = "Ирбис", Street = "Арбузова"},
            new GasStation{CostOfOneLiter = 60,BrandOfGasoline = 95, Company = "Лукойл", Street = "Кошаева"},
            new GasStation{CostOfOneLiter = 90,BrandOfGasoline = 98, Company = "Ирбис", Street = "Парковая"},
            new GasStation{CostOfOneLiter = 30,BrandOfGasoline = 95, Company = "Лукойл", Street = "Московская"},
            new GasStation{CostOfOneLiter = 50,BrandOfGasoline = 92, Company = "Ирбис", Street = "Маяковского"},
        };

        var gas = gasStations.GroupBy(x => x.Street).Select(x => new
        {
            Station = x.Where(x => x.BrandOfGasoline > 0).Count(),
            Count92 = x.Where(x => x.BrandOfGasoline == 92).Count(),
            Count95 = x.Where(x => x.BrandOfGasoline == 95).Count(),
            Count98 = x.Where(x => x.BrandOfGasoline == 98).Count(),
            Number = x.Key
        });

        Console.Write("         ----------------------------------    \n");
        Console.WriteLine("            Улица       |  92 |  95 |  98 |      ");
        Console.Write("         ---------------|-----|-----|-----|    \n");
        foreach (var g in gas)
        {
            Console.WriteLine($"\t    {g.Number}\t|  {g.Count92}  |  {g.Count95}  |  {g.Count98}  |");
        }
        Console.Write("         ----------------------------------    \n");
    }

    public static void Task52()
    {
        var exams = new List<Exam>
        {
            new Exam{Surname = "Иванов", Initsial = "А.И", SchoolNumber = 1, PointExam = "91 90 99"},
            new Exam { Surname = "Петров", Initsial = "В.С", SchoolNumber = 2, PointExam = "59 64 63" },
            new Exam { Surname = "Сидоров", Initsial = "Е.Р", SchoolNumber = 2, PointExam = "79 90 100" },
            new Exam { Surname = "Белов", Initsial = "И.З", SchoolNumber = 3, PointExam = "27 43 51" },
            new Exam { Surname = "Гагарин", Initsial = "Е.В", SchoolNumber = 3, PointExam = "53 47 40" },
            new Exam { Surname = "Сахаров", Initsial = "Э.К", SchoolNumber = 3, PointExam = "87 84 55" },
            new Exam { Surname = "Суворов", Initsial = "Ф.Н", SchoolNumber = 1, PointExam = "90 20 10" }
        };


        var students = exams.GroupBy(x => x.SchoolNumber).Select(x => new
        {
            MinPoint = x.Min(x => x.PointExam),
            MinSumPoints = x.Where(x => x.PointExam == exams.Min(x => x.PointExam))
            .Select(x => x.PointExam.Split(' ')).SelectMany(x => x)
            .Select(x => int.Parse(x)).Sum(),
            Student = x.Where(x => x.PointExam == exams.Min(x => x.PointExam)).Select(x => new {x.Surname, x.Initsial})
            .OrderBy(x => x.Surname).ThenBy(x => x.Initsial),
            SchoolNumber = x.Key
        });

        foreach (var st in students)
        {
            Console.WriteLine($"Школа: {st.SchoolNumber}, Минимальный балл: {st.MinSumPoints}");
            foreach(var s in st.Student)
            {
                Console.WriteLine($"Ученик {s.Surname} {s.Initsial}");
            }
        }
        Console.WriteLine("----------------------------");
        var users = from user in exams
                    group user by user.SchoolNumber into eGroup
                    let minSumPoint = eGroup.Min(x => x.PointExam)
                    let minPoint = eGroup
                    .Where(x => x.PointExam == minSumPoint)
                    .Select(x => x.PointExam.Split(' '))
                    .SelectMany(x => x)
                    .Select(x => int.Parse(x))
                    .Sum()
                    select new
                    {
                        NumberSchool = eGroup.Key,
                        Insial = eGroup
                        .Where(x => x.PointExam == minSumPoint)
                        .Select(x => new { x.Surname, x.Initsial })
                        .OrderBy(x => x.Surname).ThenBy(x => x.Initsial),
                        SumPoint = minPoint
                    };

        foreach (var user in users)
        {
            Console.WriteLine($"Школа: {user.NumberSchool}, Минимальный балл: {user.SumPoint}");
            foreach (var item in user.Insial)
            {
                Console.WriteLine($"Ученик: {item.Surname} {item.Initsial}");
            }
        }
    }

    public static void Task64()
    {
        var students = new List<StudentMarks>
        {
            new StudentMarks {Class = 9, Surname = "Иванов", Initials = "И.И", SubjectName = "Информатика", Mark = 4.8},
            new StudentMarks {Class = 7, Surname = "Петров", Initials = "А.И", SubjectName = "Алгебра", Mark = 3.2},
            new StudentMarks {Class = 9, Surname = "Сидоров", Initials = "Е.И", SubjectName = "Геометрия", Mark = 3.8},
            new StudentMarks {Class = 10, Surname = "Смирнов", Initials = "И.Н", SubjectName = "Геометрия", Mark = 4.7},
            new StudentMarks {Class = 11, Surname = "Гагарин", Initials = "Е.Н", SubjectName = "Информатика", Mark = 4.2},
            new StudentMarks {Class = 9, Surname = "Жуков", Initials = "Ф.И", SubjectName = "Алгебра", Mark = 2.5},
            new StudentMarks {Class = 8, Surname = "Борисов", Initials = "И.К", SubjectName = "Информатика", Mark = 3.8},
            new StudentMarks {Class = 9, Surname = "Дятлов", Initials = "К.Ф", SubjectName = "Геометрия", Mark = 5.0},
            new StudentMarks {Class = 10, Surname = "Васильев", Initials = "Р.А", SubjectName = "Алгебра", Mark = 4.1},
            new StudentMarks {Class = 9, Surname = "Горшков", Initials = "А.Н", SubjectName = "Информатика", Mark = 3.4},
            new StudentMarks {Class = 6, Surname = "Цветков", Initials = "К.З", SubjectName = "Информатика", Mark = 3.8},
            new StudentMarks {Class = 9, Surname = "Сахаров", Initials = "К.Н", SubjectName = "Информатика", Mark = 5.0},
            new StudentMarks {Class = 8, Surname = "Суворов", Initials = "И.Ф", SubjectName = "Геометрия", Mark = 2.7},
            new StudentMarks {Class = 9, Surname = "Никитин", Initials = "С.А", SubjectName = "Информатика", Mark = 5.0},
            new StudentMarks {Class = 11, Surname = "Рябов", Initials = "С.И", SubjectName = "Алгебра", Mark = 3.7},
            new StudentMarks {Class = 9, Surname = "Белов", Initials = "И.С", SubjectName = "Информатика", Mark = 4.5},
            new StudentMarks {Class = 10, Surname = "Соколов", Initials = "И.Р", SubjectName = "Алгебра", Mark = 3.8},
            new StudentMarks {Class = 9, Surname = "Попов", Initials = "Ф.М", SubjectName = "Геометрия", Mark = 5.0},
            new StudentMarks {Class = 8, Surname = "Михайлов", Initials = "Д.И", SubjectName = "Информатика", Mark = 4.7},
            new StudentMarks {Class = 7, Surname = "Федотов", Initials = "И.Д", SubjectName = "Информатика", Mark = 2.6},
        };

        var student = students.GroupBy(x => x.SubjectName).Select(x => new
        {
            Count = x.Where(x => x.SubjectName == "Информатика").Count(),
            Student = x.Where(x => x.Mark >= 4.0)
        });

        foreach(var st in student.OrderBy(x => x.Count))
        {
            foreach(var s in st.Student.OrderBy(x => x.Class))
            {
                Console.WriteLine($"Класс: {s.Class}, Учащийся: {s.Surname} {s.Initials}, " +
                    $"Средняя оценка по информатике : {s.Mark} ");
            }
        }
        //var st = from students in list
        //         group students by students.SubjectName into eGroup
        //         let count = eGroup.Where(x => x.SubjectName == "Информатика").Count()
        //         let mark = eGroup.Where(x => x.SubjectName == "Информатика").Sum(x => x.Mark)
        //         select new
        //         {
        //             Number = eGroup.Key,
        //             Insial = eGroup.Where(x => x.Mark >= 4.0)
        //         };
        //foreach (var item in st)
        //{
        //    foreach (var student in item.Insial.OrderBy(x => x.Class))
        //    {
        //        Console.WriteLine($"Класс: {student.Class}, Учащийся: {student.Surname} {student.Initials}, " +
        //            $"Средняя оценка по информатике : {student.Mark} ");
        //    }
        //}
    }
}