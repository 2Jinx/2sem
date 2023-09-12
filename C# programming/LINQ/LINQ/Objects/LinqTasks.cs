using System;
namespace LINQ
{
    public class LinqTasks
    {
        /// <summary>
        /// 4 задача по LINQ
        /// </summary>
        public void Task4()
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
            Console.WriteLine("Задание 4...\n");
            Console.Write("      ---------------------------------------------------    \n");
            Console.WriteLine("\tСуммарная продолжительность    |   Код клиента\t|");
            Console.WriteLine("\t           часов   \t       |\t        |");
            Console.Write("      ---------------------------------------------------    \n");
            foreach (var item in year.OrderBy(x => x.Code).ThenBy(x => -x.Time))
            {
                Console.WriteLine($"\t\t    {item.Time} \t\t       |        {item.Code}\t|");
            }
            Console.Write("      ---------------------------------------------------    \n");
        }
        /// <summary>
        /// 16 задача по LINQ
        /// </summary>
        public void Task16()
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
            Console.WriteLine("\nЗадание 16...\n");
            Console.Write("      -------------------------------------------    \n");
            Console.WriteLine("\tКол-во абитуриентов\t|\tГод\t|");
            Console.Write("      -------------------------------------------    \n");
            foreach (var item in abiturient.OrderBy(x => -x.CountAbiturient).ThenBy(x => x.Year))
            {
                Console.WriteLine($"\t         {item.CountAbiturient}\t\t|\t{item.Year}\t|");
            }
            Console.Write("      -------------------------------------------    \n");
        }
        /// <summary>
        /// 28 задача по LINQ
        /// </summary>
        public void Task28()
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
            Console.WriteLine("\n\nЗадание 28...\n");
            Console.Write("      ---------------------------------------------------    \n");
            Console.WriteLine("\tКол-во должников    |\tЭтаж\t|  Задолжность\t|");
            Console.Write("      ---------------------------------------------------    \n");
            foreach (var d in debtor.OrderBy(x => x.Ground))
            {
                Console.WriteLine($"\t       {d.Count}\t    |\t {d.Ground}\t|    {d.Cost:F2}\t|");
            }
            Console.Write("      ---------------------------------------------------    \n");
        }
        /// <summary>
        /// 37 задача по LINQ
        /// </summary>
        public void Task37()
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
            Console.WriteLine("\n\nЗадание 37...\n");
            Console.Write("      -----------------------------------------------------    \n");
            Console.WriteLine("\t Марка\t|      Максимальная   \t|   Минимальная   |");
            Console.WriteLine("\t\t|          цена\t\t|       цена\t  |");
            Console.Write("      -----------------------------------------------------    \n");
            foreach (var g in gas.OrderBy(x => x.Station).ThenBy(x => -x.Number))
            {
                Console.WriteLine($"\t  {g.Number} \t|\t    {g.Max}\t\t|\t {g.Min}\t  |");
            }
            Console.Write("      -----------------------------------------------------    \n");
        }
        /// <summary>
        /// 40 задача по LINQ
        /// </summary>
        public void Task40()
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
            Console.WriteLine("\n\nЗадание 40...\n");
            Console.Write("         ----------------------------------    \n");
            Console.WriteLine("            Улица       |  92 |  95 |  98 |      ");
            Console.Write("         ---------------|-----|-----|-----|    \n");
            foreach (var g in gas)
            {
                Console.WriteLine($"\t    {g.Number}\t|  {g.Count92}  |  {g.Count95}  |  {g.Count98}  |");
            }
            Console.Write("         ----------------------------------    \n");
        }
        /// <summary>
        /// 52 задача по LINQ
        /// </summary>
        public void Task52()
        {
            var exams = new List<Exam>
            {
                new Exam {Surname = "Суворов", Initsial = "А.И", SchoolNumber = 1, PointExam = "89 90 99"},
                new Exam { Surname = "Петров", Initsial = "В.С", SchoolNumber = 2, PointExam = "59 64 63" },
                new Exam { Surname = "Сидоров", Initsial = "Е.Р", SchoolNumber = 2, PointExam = "79 90 100" },
                new Exam { Surname = "Белов", Initsial = "И.З", SchoolNumber = 3, PointExam = "27 43 51" },
                new Exam { Surname = "Гагарин", Initsial = "Е.В", SchoolNumber = 3, PointExam = "53 47 40" },
                new Exam { Surname = "Сахаров", Initsial = "Э.К", SchoolNumber = 3, PointExam = "87 84 55" },
                new Exam { Surname = "Иванов", Initsial = "Ф.Н", SchoolNumber = 1, PointExam = "90 20 10" }
            };

            var students = exams.Select(x =>
            {
                var parts = x.PointExam.Split(' ');
                return new
                {
                    Points = int.Parse(parts[0]) + int.Parse(parts[1]) + int.Parse(parts[2]),
                    SchoolNumber = x.SchoolNumber,
                    Surname = x.Surname,
                    Initsial = x.Initsial
                };
            }).GroupBy(x => x.SchoolNumber).OrderBy(g => g.Key).Select(g =>
            {
                var student = g.OrderBy(s => s.Points).ThenBy(s => s.Surname).First();
                return $"\t\t     {student.SchoolNumber} \t\t|\t{student.Surname} {student.Initsial} \t|\t   {student.Points} \t\t|";
            });
            Console.WriteLine("\n\nЗадание 52...\n");
            Console.Write("         ------------------------------------------------------------------------    \n");
            Console.WriteLine("            Школа       \t|\t  Ученик \t|\t  Баллы ЕГЭ \t|      ");
            Console.Write("         ------------------------------------------------------------------------    \n");
            foreach (var s in students)
            {
                Console.WriteLine(s);
            }
            Console.Write("         ------------------------------------------------------------------------    \n");

        }
        /// <summary>
        /// 64 задача по LINQ
        /// </summary>
        public void Task64()
        {
            var marks = new List<StudentMarks>
            {
                new StudentMarks {Class = 9, Surname = "Иванов", Initials = "И.И", SubjectName = "Информатика", Mark = 4},
                new StudentMarks {Class = 7, Surname = "Петров", Initials = "А.И", SubjectName = "Алгебра", Mark = 3},
                new StudentMarks {Class = 9, Surname = "Сидоров", Initials = "Е.И", SubjectName = "Геометрия", Mark = 3},
                new StudentMarks {Class = 10, Surname = "Смирнов", Initials = "И.Н", SubjectName = "Геометрия", Mark = 4},
                new StudentMarks {Class = 11, Surname = "Гагарин", Initials = "Е.Н", SubjectName = "Информатика", Mark = 4},
                new StudentMarks {Class = 9, Surname = "Жуков", Initials = "Ф.И", SubjectName = "Алгебра", Mark = 2},
                new StudentMarks {Class = 8, Surname = "Борисов", Initials = "И.К", SubjectName = "Информатика", Mark = 3},
                new StudentMarks {Class = 9, Surname = "Дятлов", Initials = "К.Ф", SubjectName = "Геометрия", Mark = 5},
                new StudentMarks {Class = 10, Surname = "Васильев", Initials = "Р.А", SubjectName = "Алгебра", Mark = 4},
                new StudentMarks {Class = 9, Surname = "Горшков", Initials = "А.Н", SubjectName = "Информатика", Mark = 3},
                new StudentMarks {Class = 6, Surname = "Цветков", Initials = "К.З", SubjectName = "Информатика", Mark = 3},
                new StudentMarks {Class = 9, Surname = "Сахаров", Initials = "К.Н", SubjectName = "Информатика", Mark = 5},
                new StudentMarks {Class = 8, Surname = "Суворов", Initials = "И.Ф", SubjectName = "Геометрия", Mark = 2},
                new StudentMarks {Class = 9, Surname = "Никитин", Initials = "С.А", SubjectName = "Информатика", Mark = 5},
                new StudentMarks {Class = 11, Surname = "Рябов", Initials = "С.И", SubjectName = "Алгебра", Mark = 3},
                new StudentMarks {Class = 9, Surname = "Белов", Initials = "И.С", SubjectName = "Информатика", Mark = 4},
                new StudentMarks {Class = 10, Surname = "Соколов", Initials = "И.Р", SubjectName = "Алгебра", Mark = 3},
                new StudentMarks {Class = 9, Surname = "Попов", Initials = "Ф.М", SubjectName = "Геометрия", Mark = 5},
                new StudentMarks {Class = 7, Surname = "Федотов", Initials = "И.Д", SubjectName = "Информатика", Mark = 2},

                new StudentMarks {Class = 9, Surname = "Иванов", Initials = "И.И", SubjectName = "Информатика", Mark = 3},
                new StudentMarks {Class = 7, Surname = "Петров", Initials = "А.И", SubjectName = "Алгебра", Mark = 4},
                new StudentMarks {Class = 9, Surname = "Сидоров", Initials = "Е.И", SubjectName = "Геометрия", Mark = 2},
                new StudentMarks {Class = 10, Surname = "Смирнов", Initials = "И.Н", SubjectName = "Геометрия", Mark = 5},
                new StudentMarks {Class = 11, Surname = "Гагарин", Initials = "Е.Н", SubjectName = "Информатика", Mark = 5},
                new StudentMarks {Class = 9, Surname = "Жуков", Initials = "Ф.И", SubjectName = "Алгебра", Mark = 3},
                new StudentMarks {Class = 8, Surname = "Борисов", Initials = "И.К", SubjectName = "Информатика", Mark = 3},
                new StudentMarks {Class = 9, Surname = "Дятлов", Initials = "К.Ф", SubjectName = "Геометрия", Mark = 4},
                new StudentMarks {Class = 10, Surname = "Васильев", Initials = "Р.А", SubjectName = "Алгебра", Mark = 5},
                new StudentMarks {Class = 9, Surname = "Горшков", Initials = "А.Н", SubjectName = "Информатика", Mark = 2},
                new StudentMarks {Class = 6, Surname = "Цветков", Initials = "К.З", SubjectName = "Информатика", Mark = 3},
                new StudentMarks {Class = 9, Surname = "Сахаров", Initials = "К.Н", SubjectName = "Информатика", Mark = 4},
                new StudentMarks {Class = 8, Surname = "Суворов", Initials = "И.Ф", SubjectName = "Геометрия", Mark = 3},
                new StudentMarks {Class = 9, Surname = "Никитин", Initials = "С.А", SubjectName = "Информатика", Mark = 4},
                new StudentMarks {Class = 11, Surname = "Рябов", Initials = "С.И", SubjectName = "Алгебра", Mark = 4},
                new StudentMarks {Class = 9, Surname = "Белов", Initials = "И.С", SubjectName = "Информатика", Mark = 4},
                new StudentMarks {Class = 10, Surname = "Соколов", Initials = "И.Р", SubjectName = "Алгебра", Mark = 5},
                new StudentMarks {Class = 9, Surname = "Попов", Initials = "Ф.М", SubjectName = "Геометрия", Mark = 2},
                new StudentMarks {Class = 7, Surname = "Федотов", Initials = "И.Д", SubjectName = "Информатика", Mark = 4},

                new StudentMarks {Class = 9, Surname = "Иванов", Initials = "И.И", SubjectName = "Информатика", Mark = 5},
                new StudentMarks {Class = 7, Surname = "Петров", Initials = "А.И", SubjectName = "Алгебра", Mark = 2},
                new StudentMarks {Class = 9, Surname = "Сидоров", Initials = "Е.И", SubjectName = "Геометрия", Mark = 4},
                new StudentMarks {Class = 10, Surname = "Смирнов", Initials = "И.Н", SubjectName = "Геометрия", Mark = 3},
                new StudentMarks {Class = 11, Surname = "Гагарин", Initials = "Е.Н", SubjectName = "Информатика", Mark = 4},
                new StudentMarks {Class = 9, Surname = "Жуков", Initials = "Ф.И", SubjectName = "Алгебра", Mark = 5},
                new StudentMarks {Class = 8, Surname = "Борисов", Initials = "И.К", SubjectName = "Информатика", Mark = 4},
                new StudentMarks {Class = 9, Surname = "Дятлов", Initials = "К.Ф", SubjectName = "Геометрия", Mark = 2},
                new StudentMarks {Class = 10, Surname = "Васильев", Initials = "Р.А", SubjectName = "Алгебра", Mark = 3},
                new StudentMarks {Class = 9, Surname = "Горшков", Initials = "А.Н", SubjectName = "Информатика", Mark = 5},
                new StudentMarks {Class = 6, Surname = "Цветков", Initials = "К.З", SubjectName = "Информатика", Mark = 5},
                new StudentMarks {Class = 9, Surname = "Сахаров", Initials = "К.Н", SubjectName = "Информатика", Mark = 3},
                new StudentMarks {Class = 8, Surname = "Суворов", Initials = "И.Ф", SubjectName = "Геометрия", Mark = 5},
                new StudentMarks {Class = 9, Surname = "Никитин", Initials = "С.А", SubjectName = "Информатика", Mark = 3},
                new StudentMarks {Class = 11, Surname = "Рябов", Initials = "С.И", SubjectName = "Алгебра", Mark = 2},
                new StudentMarks {Class = 9, Surname = "Белов", Initials = "И.С", SubjectName = "Информатика", Mark = 3},
                new StudentMarks {Class = 10, Surname = "Соколов", Initials = "И.Р", SubjectName = "Алгебра", Mark = 5},
                new StudentMarks {Class = 9, Surname = "Попов", Initials = "Ф.М", SubjectName = "Геометрия", Mark = 5},
                new StudentMarks {Class = 7, Surname = "Федотов", Initials = "И.Д", SubjectName = "Информатика", Mark = 4},

                new StudentMarks {Class = 9, Surname = "Иванов", Initials = "И.И", SubjectName = "Информатика", Mark = 3},
                new StudentMarks {Class = 7, Surname = "Петров", Initials = "А.И", SubjectName = "Алгебра", Mark = 4},
                new StudentMarks {Class = 9, Surname = "Сидоров", Initials = "Е.И", SubjectName = "Геометрия", Mark = 5},
                new StudentMarks {Class = 10, Surname = "Смирнов", Initials = "И.Н", SubjectName = "Геометрия", Mark = 2},
                new StudentMarks {Class = 11, Surname = "Гагарин", Initials = "Е.Н", SubjectName = "Информатика", Mark = 3},
                new StudentMarks {Class = 9, Surname = "Жуков", Initials = "Ф.И", SubjectName = "Алгебра", Mark = 5},
                new StudentMarks {Class = 8, Surname = "Борисов", Initials = "И.К", SubjectName = "Информатика", Mark = 5},
                new StudentMarks {Class = 9, Surname = "Дятлов", Initials = "К.Ф", SubjectName = "Геометрия", Mark = 4},
                new StudentMarks {Class = 10, Surname = "Васильев", Initials = "Р.А", SubjectName = "Алгебра", Mark = 3},
                new StudentMarks {Class = 9, Surname = "Горшков", Initials = "А.Н", SubjectName = "Информатика", Mark = 2},
                new StudentMarks {Class = 6, Surname = "Цветков", Initials = "К.З", SubjectName = "Информатика", Mark = 4},
                new StudentMarks {Class = 9, Surname = "Сахаров", Initials = "К.Н", SubjectName = "Информатика", Mark = 4},
                new StudentMarks {Class = 8, Surname = "Суворов", Initials = "И.Ф", SubjectName = "Геометрия", Mark = 5},
                new StudentMarks {Class = 9, Surname = "Никитин", Initials = "С.А", SubjectName = "Информатика", Mark = 5},
                new StudentMarks {Class = 11, Surname = "Рябов", Initials = "С.И", SubjectName = "Алгебра", Mark = 4},
                new StudentMarks {Class = 9, Surname = "Белов", Initials = "И.С", SubjectName = "Информатика", Mark = 5},
                new StudentMarks {Class = 10, Surname = "Соколов", Initials = "И.Р", SubjectName = "Алгебра", Mark = 5},
                new StudentMarks {Class = 9, Surname = "Попов", Initials = "Ф.М", SubjectName = "Геометрия", Mark = 5},
                new StudentMarks {Class = 7, Surname = "Федотов", Initials = "И.Д", SubjectName = "Информатика", Mark = 3}
            };

            var students = marks.Where(x => x.SubjectName == "Информатика").OrderBy(x => x.Class).GroupBy(x => x.Surname).Select(x => new
            {
                AverageMark = x.Sum(x => x.Mark) / x.Count(),
                Student = x.Select(x => new { x.Class, x.Surname, x.Initials })
            });
            Console.WriteLine("\n\nЗадание 64...\n");
            Console.Write("      -------------------------------------------------------    \n");
            Console.WriteLine("\t Класс\t   |\t   Ученик\t|     Средний балл  |");
            Console.Write("      -------------------------------------------------------    \n");
            foreach (var s in students.Where(x => x.AverageMark >= 4.0))
            {
                foreach (var k in s.Student.Distinct())
                {
                    Console.Write($"\t   {k.Class}\t   |\t{k.Surname} {k.Initials}\t|");
                }
                Console.Write($"        {s.AverageMark:F1}\t    |\n");
            }
            Console.Write("      -------------------------------------------------------    \n");
        }
        /// <summary>
        /// 76 задача по LINQ
        /// </summary>
        public void Task76()
        {

            var b = new List<B>()
            {
                new B{VendorCode = 12345, Category = "Фрукты", Country = "Марокко"},
                new B{VendorCode = 75284, Category = "Техника", Country = "Китай"},
                new B{VendorCode = 62477, Category = "Автомобили", Country = "Германия"},
                new B{VendorCode = 62858, Category = "Овощи", Country = "Марокко"},
                new B{VendorCode = 74821, Category = "Техника", Country = "Китай"},
                new B{VendorCode = 62910, Category = "Автомобили", Country = "Германия"}
            };

            var d = new List<D>()
            {
                new D{VendorCode = 12345, StoreName = "GoodFood", Price = 200},
                new D{VendorCode = 75284, StoreName = "Xiaomi", Price = 23499},
                new D{VendorCode = 62477, StoreName = "BMW", Price = 6799000},
                new D{VendorCode = 62858, StoreName = "GoodFood", Price = 500},
                new D{VendorCode = 74821, StoreName = "Xiaomi", Price = 43499},
                new D{VendorCode = 62910, StoreName = "BMW", Price = 16799000}
            };

            var result = b
                .Select(s =>
                {
                    return new
                    {
                        Country = s.Country,
                        Category = s.Category,
                        ProductId = s.VendorCode
                    };
                })
                .Join(d, b => b.ProductId, d => d.VendorCode, (b, d) => new
                {
                    b.ProductId,
                    b.Country,
                    d.StoreName,
                    d.Price
                })
                .GroupBy(s => s.Country)
                .OrderBy(g => g.Count())
                .ThenBy(g => g.Key)
                .Select(g =>
                {
                    var count = g.Count();
                    var minPrice = count > 0 ? g.Min(s => s.Price) : 0;
                    return $"{count} {g.Key} {minPrice}";
                });
            Console.WriteLine("\n\nЗадание 76...\n");
            foreach (var s in result)
            {
                Console.WriteLine(s);
            }
        }
        /// <summary>
        /// 88 задача по LINQ
        /// </summary>
        public void Task88()
        {
            List<A> a = new List<A>()
            {
                new A() {Street = "Московская", Code = 11, BirthYear = 2004},
                new A() {Street = "Парина", Code = 11, BirthYear = 2004},
                new A() {Street = "Тукая", Code = 22, BirthYear = 2004},
                new A() {Street = "Баумана", Code = 44, BirthYear = 2006},
                new A() {Street = "Матросова", Code = 55, BirthYear = 2006},
                new A() {Street = "Малова", Code = 22, BirthYear = 2008},
                new A() {Street = "Гагарина", Code = 88, BirthYear = 2008},
                new A() {Street = "Столова", Code = 88, BirthYear = 2000},
            };

            List<D> d = new List<D>()
            {
                new D() { VendorCode = 65274, Price = 344, StoreName = "Лента"},
                new D() { VendorCode = 28912, Price = 876, StoreName = "Пяторочка"},
                new D() { VendorCode = 87234, Price = 986, StoreName = "Лента"},
                new D() { VendorCode = 81424, Price = 232, StoreName = "Перекресток"},
                new D() { VendorCode = 19494, Price = 6634, StoreName = "Магнит"},
            };

            List<E> e = new List<E>()
            {
                new E() { VendorCode = 65274, Code = 11, StoreName = "Лента"},
                new E() { VendorCode = 28912, Code = 11, StoreName = "Пяторочка"},
                new E() { VendorCode = 87234, Code = 11, StoreName = "Лента"},
                new E() { VendorCode = 81424, Code = 11, StoreName = "Перекресток"},
                new E() { VendorCode = 19494, Code = 11, StoreName = "Магнит"}
            };

            var result = a
                .Join(e, a => new { a.Code }, e => new { e.Code }, (a, e) => new { VendorCode = e.VendorCode,
                    BirthYear = a.BirthYear, StoreName = e.StoreName, Code = a.Code })
                .Join(d, ae => new { ae.VendorCode, ae.StoreName }, d => new { d.VendorCode, d.StoreName },
                    (ae, d) => new { Id = ae.VendorCode, Year = ae.BirthYear, Shop = ae.StoreName, IdCustomer = ae.Code, d.Price })
                .GroupBy(x => new { x.Year, x.Id })
                .Select(x => new { Year = x.First().Year, Id = x.First().Id, Sum = x.Sum(y => y.Price) });

            Console.WriteLine("\n\nЗадание 88...\n");
            foreach (var item in result)
            {
                Console.WriteLine($"{item.Year} {item.Id} {item.Sum}");
            }
        }
        /// <summary>
        /// 100 задача по LINQ
        /// </summary>
        public void Task100()
        {
            List<A> consumers = new List<A>
            {
                new A { Street = "ул. Ленина", Code = 1, BirthYear = 1990 },
                new A { Street = "ул. Пушкина", Code = 2, BirthYear = 1985 },
                new A { Street = "ул. Гагарина", Code = 3, BirthYear = 2000 },
                new A { Street = "ул. Садовая", Code = 4, BirthYear = 1995 }
            };

            List<B> products = new List<B>
            {
                new B { VendorCode = 76231, Country = "Россия", Category = "Техника" },
                new B { VendorCode = 61948, Country = "США", Category = "Техника" },
                new B { VendorCode = 51342, Country = "Германия", Category = "Автомобили" },
                new B { VendorCode = 14897, Country = "Япония", Category = "Автомобили" },

                new B { VendorCode = 43231, Country = "Россия", Category = "Техника" },
                new B { VendorCode = 91948, Country = "США", Category = "Техника" },
                new B { VendorCode = 52342, Country = "Германия", Category = "Автомобили" },
                new B { VendorCode = 14897, Country = "Япония", Category = "Автомобили" }
            };

            List<D> storeItems = new List<D>
            {
                new D { StoreName = "МВидео", Price = 15999, VendorCode = 76231 },
                new D { StoreName = "Apple", Price = 76000, VendorCode = 61948 },
                new D { StoreName = "BMW", Price = 6599000, VendorCode = 51342 },
                new D { StoreName = "Toyota", Price = 5433000, VendorCode = 14897 },

                new D { StoreName = "МВидео", Price = 38999, VendorCode = 43231 },
                new D { StoreName = "Apple", Price = 13999, VendorCode = 91948 },
                new D { StoreName = "BMW", Price = 8599000, VendorCode = 52342 },
                new D { StoreName = "Toyota", Price = 2433000, VendorCode = 28901 }
            };

            List<E> e = new List<E>
            {
                new E { VendorCode = 76231, Code = 1, StoreName = "МВидео" },
                new E { VendorCode = 61848, Code = 1, StoreName = "Apple" },
                new E { VendorCode = 51342, Code = 2, StoreName = "BMW" },
                new E { VendorCode = 14897, Code = 3, StoreName = "Toyota" },
                new E { VendorCode = 76231, Code = 4, StoreName = "МВидео" },

                new E { VendorCode = 43231, Code = 1, StoreName = "МВидео" },
                new E { VendorCode = 91948, Code = 1, StoreName = "Apple" },
                new E { VendorCode = 52342, Code = 2, StoreName = "BMW" },
                new E { VendorCode = 28901, Code = 3, StoreName = "Toyota" },
                new E { VendorCode = 76231, Code = 4, StoreName = "МВидео" }
            };

            var result = e
            .Join(consumers, p => p.Code, c => c.Code, (p, c) => new { Purchase = p, Consumer = c })
            .Join(products, pc => pc.Purchase.VendorCode, pr => pr.VendorCode, (pc, pr) => new { pc.Consumer, pc.Purchase, Product = pr })
            .Join(storeItems, pcr => pcr.Purchase.VendorCode, si => si.VendorCode, (pcr, si) => new { pcr.Consumer, pcr.Product, StoreItem = si })
            .GroupBy(x => new { x.Product.Country, x.StoreItem.StoreName, x.Consumer.Code, x.Consumer.BirthYear })
            .Select(g => new
            {
                Country = g.Key.Country,
                StoreName = g.Key.StoreName,
                ConsumerCode = g.Key.Code,
                BirthYear = g.Key.BirthYear,
                TotalPrice = g.Sum(x => x.StoreItem.Price)
            })
            .GroupBy(x => new { x.Country, x.StoreName })
            .Select(g => new
            {
                Country = g.Key.Country,
                StoreName = g.Key.StoreName,
                MaxBirthYear = g.Max(x => x.BirthYear),
                Consumers = g.Where(x => x.BirthYear == g.Max(y => y.BirthYear)).OrderBy(x => x.ConsumerCode)
            })
            .OrderBy(x => x.Country).ThenBy(x => x.StoreName);
            Console.WriteLine("\n\nЗадание 100...\n");
            foreach (var countryStore in result)
            {
                foreach (var consumer in countryStore.Consumers)
                {
                    Console.WriteLine($"{countryStore.Country} {countryStore.StoreName} {consumer.BirthYear} {consumer.ConsumerCode} {consumer.TotalPrice}");
                }
            }
        }
    }
}

