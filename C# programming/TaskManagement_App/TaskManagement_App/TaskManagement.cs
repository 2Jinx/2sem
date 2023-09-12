using System;
namespace TaskManagement_App
{
	public class TaskManagement
	{
        public List<Project> Projects { get; set; } = new List<Project>();
        public List<Customer> Customers { get; set; } = new List<Customer>();
        public List<Task> Tasks { get; set; } = new List<Task>();
        public List<Employee> Employees { get; set; } = new List<Employee>();
        public List<Position> Positions { get; set; } = new List<Position>();
        private Project proj { get; set; }
        private Position pos { get; set; }

        public void Init()
        {
            Projects.Clear();

            //сотрудники компании

            Employees.Add(new Employee()
            {
                FullName = "Марк Эллиот Цукерберг",
                Number = 1,
                Rating = 5
            });
            Employees.Add(new Employee()
            {
                FullName = "Гвидо ван Россум",
                Number = 2,
                Rating = 5
            });
            Employees.Add(new Employee()
            {
                FullName = "Cтанчу Данил Владимирович",
                Number = 3,
                Rating = 1
            });
            Employees.Add(new Employee()
            {
                FullName = "Сидоров Валентин Константинович",
                Number = 4,
                Rating = 3
            });
            Employees.Add(new Employee()
            {
                FullName = "Иванов Николай Петрович",
                Number = 5,
                Rating = 3
            });
            Employees.Add(new Employee()
            {
                FullName = "Петров Константин Алексеевич",
                Number = 6,
                Rating = 2
            });
            Employees.Add(new Employee()
            {
                FullName = "Калинин Алексей Викторович",
                Number = 7,
                Rating = 1
            });
            Employees.Add(new Employee()
            {
                FullName = "Максимов Борис Сергеевич",
                Number = 8,
                Rating = 3
            });

            // клиенты компании

            Customers.Add(new Customer()
            {
                Name = "Иванов",
                ContactEmail = "ivanovAlexey@mail.ru",
                ContactPerson = "Иванов Алексей Константинович",
                ContactPhone = "+7 (919) 535-32-15"
            });
            Customers.Add(new Customer()
            {
                Name = "Сахаров",
                ContactEmail = "saharovIvan@mail.ru",
                ContactPerson = "Сахаров Иван Александрович",
                ContactPhone = "+7 (917) 521-47-69"
            });

            // должности в компании

            Positions.Add(new Position()
            {
                Code = 1,
                Name = "начинающий разработчик",
                BaseHourlyRate = 8,
                HourlyRate = 300
            });
            Positions.Add(new Position()
            {
                Code = 2,
                Name = "средний разработчик",
                BaseHourlyRate = 8,
                HourlyRate = Math.Round(300 + (300 * 0.05),0)
            });
            Positions.Add(new Position()
            {
                Code = 3,
                Name = "продвинутый разработчик",
                BaseHourlyRate = 8,
                HourlyRate = Math.Round(300 + (300 * 0.1), 0)
            });
            Positions.Add(new Position()
            {
                Code = 4,
                Name = "разработчик высокого уровня",
                BaseHourlyRate = 8,
                HourlyRate = Math.Round(300 + (300 * 0.15), 0)
            });
            Positions.Add(new Position()
            {
                Code = 5,
                Name = "ведущий разработчик",
                BaseHourlyRate = 8,
                HourlyRate = Math.Round(300 + (300 * 0.2), 0)
            });
        }

        public void PrintEmployees()
        {
            Console.WriteLine("Список сотрудников :");
            foreach (var empl in Employees)
            {
                Console.WriteLine(empl);
            }
        }
        public void PrintTasks(int projKey)
        {
            Console.WriteLine("Список задач :");
            foreach (var k in Projects)
            {
                if (k.Key == projKey)
                {
                    foreach (var task in Tasks)
                    {
                        Console.WriteLine(task);
                    }
                }
            }
        }

        public void PrintCustomers()
        {
            Console.WriteLine("Список заказчиков :");
            foreach (var cust in Customers)
            {
                Console.WriteLine(cust);
            }
        }

        public void PrintProjects(int projKey)
        {
            Console.WriteLine("Список проектов :");
            if (Projects.Count == 0)
            {
                Console.WriteLine("Список проектов пуст. Вы можете добавить проект в 4 пункте меню.");
            }
            else
            {
                foreach (var k in Projects)
                {
                    if (k.Key == projKey)
                    {
                        foreach (var proj in Projects)
                        {
                            Console.WriteLine(proj);
                        }
                    }
                }
            }
            Console.WriteLine();
        }

        public bool ExistCustomer(string name)
        {
            foreach (var c in Customers)
            {
                if (c.Name == name)
                    return true;
            }
            return false;
        }


        public bool ExistEmployee(int eId)
        {
            foreach (var e in Employees)
            {
                if (e.Number == eId)
                    return true;
            }
            return false;
        }
        public void AddNewTask(string descript,int tNum, int eId, int days, bool isBillable)
        {
            Employee empl = null;
            foreach (var e in Employees)
            {
                if (e.Number == eId)
                    empl = e;
            }
            var newTask = new Task(empl,tNum, descript, days, isBillable);
            Tasks.Add(newTask);
            Console.WriteLine("Задача добавлена задача в проект:");

        }
        public void AddNewProject(string custName, int taskNum,int initCost, string projName, int projKey)
        {
            Task task = null;
            Customer cust = null;
            foreach (var c in Customers)
            {
                if (c.Name == custName)
                    cust = c;
            }
            foreach (var t in Tasks)
            {
                if (t.Number == taskNum)
                    task = t;
            }
            var proj = new Project(cust,task,initCost,projName,projKey);
            Projects.Add(proj);
            Console.WriteLine("Добавлен проект:");
            Console.WriteLine(proj);
        }

        //public bool ExistTask(int taskNumber)
        //{
        //    foreach (var t in Tasks)
        //    {
        //        if (t.Number == taskNumber)
        //            return false;
        //    }
        //    return true;
        //}
        public bool ExistProject(int key)
        {
            foreach (var p in Projects)
            {
                if (p.Key == key)
                    return true;
            }
            return false;
        }

        public void AddNewEmployee(string fullName, int empId, int rat)
        {
            while (ExistEmployee(empId))
            {
                empId++;
            }
            
            Employees.Add(new Employee()
            {
                FullName = fullName,
                Number = empId,
                Rating = rat
            });
            Console.WriteLine("Добавлен новый сотрудник !");
        }

        public double CalculateTotalCost()
        {
            double finalCost = 0;
            foreach (Task task in Tasks)
            {
                double taskPrice = 0;
                if (task.Billable)
                {
                    taskPrice = task.Employee.HourlyRate * task.HoursSpent;
                    if (task.DueDate > 0)
                    {
                        taskPrice *= task.DueDate > 25 ? 1.25 : 1 + task.DueDate / 100;
                    }
                    finalCost += taskPrice;
                }
            }
            return finalCost;
        }

        //public void AddNewCustomer(string name, string fio, string phoneNum, string email)
        //{
        //    if (!ExistCustomer(fio))
        //    {
        //        Customers.Add(new Customer()
        //        {
        //            Name = name,
        //            ContactPerson = fio,
        //            ContactEmail = email,
        //            ContactPhone = phoneNum
        //        });
        //    }
        //    else
        //    {
        //        Console.WriteLine("Клиент с таким ФИО уже зарегистрирован !");
        //        PrintCustomers();
        //    }
        //}
    }
}

