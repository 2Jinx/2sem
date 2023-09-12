using System.Globalization;
using System.Xml.Linq;
using TaskManagement_App;

TaskManagement taskManagement = new TaskManagement();
taskManagement.Init();
bool exit = false;

while (!exit)
{
    Console.WriteLine();
    Console.WriteLine("╔═════════════════════════════════════════╗");
    Console.WriteLine("║                                         ║");
    Console.WriteLine("║   Выберите пункт меню:                  ║");
    Console.WriteLine("║   1. Просмотреть сотрудников компании   ║");
    Console.WriteLine("║   2. Просмотреть заказчиков             ║");
    Console.WriteLine("║   3. Просмотреть список проектов        ║");
    Console.WriteLine("║   4. Добавить проект                    ║");
    Console.WriteLine("║   5. Добавить задачу в проект           ║");
    Console.WriteLine("║   6. Просмотреть задачи проекта         ║");
    Console.WriteLine("║   7. Выход                              ║");
    Console.WriteLine("║                                         ║");
    Console.WriteLine("╚═════════════════════════════════════════╝");
    Console.WriteLine();

    var k = int.Parse(Console.ReadLine());
    Console.Clear();

    switch (k)
    {
        case 1:
            {
                taskManagement.PrintEmployees();
                break;
            }
        case 2:
            {
                taskManagement.PrintCustomers();
                break;
            }
        case 3:
            {
                Console.WriteLine("Введите цифровой ключ проекта : ");
                var pk = int.Parse(Console.ReadLine());
                if (!taskManagement.ExistProject(pk))
                {
                    Console.WriteLine("Проект не найден !");
                    break;
                }   
                taskManagement.PrintProjects(pk);
                Console.WriteLine($"стоимость проекта : {taskManagement.CalculateTotalCost()}");
                break;
            }
        case 4:
            {
                Console.WriteLine("Введите название проекта : ");
                var name = Console.ReadLine();
                Console.WriteLine("Введите бюджет проекта(в рублях) : ");
                var cost = int.Parse(Console.ReadLine());
                Console.WriteLine("Придумайте цифровой ключ проекта : ");
                var key = int.Parse(Console.ReadLine());
                Console.WriteLine("Введите Имя клиента : ");
                taskManagement.PrintCustomers();
                var cName = Console.ReadLine();
                if (!taskManagement.ExistCustomer(cName))
                    break;
                Console.WriteLine("Хотите добавить задачу?  1) да  2) нет ");
                var agree = int.Parse(Console.ReadLine());
                if (agree == 1)
                {
                    Console.WriteLine("Введите номер задачи");
                    var tNum = int.Parse(Console.ReadLine());
                    Console.WriteLine("Добавьте подробное описание : ");
                    string description = Console.ReadLine();
                    Console.WriteLine("Введите номер сотрудника, который будет выполнять задачу : ");
                    taskManagement.PrintEmployees();
                    var emplId = int.Parse(Console.ReadLine());
                    if (!taskManagement.ExistEmployee(emplId))
                        break;
                    Console.WriteLine("Введите срок исполнения задачи(в днях) : ");
                    var workDays = int.Parse(Console.ReadLine());
                    Console.WriteLine("Оплата заказчиком отдельно : 1)да 2)нет ");
                    var billable = int.Parse(Console.ReadLine());
                    bool bill;
                    if (billable == 1)
                    {
                        bill = true;
                    }
                    else
                    {
                        bill = false;
                    }
                    taskManagement.AddNewTask(description, tNum, emplId, workDays, bill);
                    taskManagement.AddNewProject(cName,tNum, cost, name, key);
                    break;
                }
                else if (agree == 2)
                {

                    taskManagement.AddNewProject(cName,0, cost, name, key);
                    break;
                }
                else
                {
                    Console.WriteLine("Ошибка! Необходимо ввести число от 1 до 2!");
                    break;
                }
            }
        case 5:
            {
                Console.WriteLine("Введите цифровой ключ проекта : ");
                var projKey = int.Parse(Console.ReadLine());
                if (!taskManagement.ExistProject(projKey))
                    break;
                Console.WriteLine("Введите номер задачи : ");
                var tNum = int.Parse(Console.ReadLine());
                Console.WriteLine("Добавьте подробное описание :");
                string description = Console.ReadLine();
                Console.WriteLine("Введите номер сотрудника, который будет выполнять задачу ");
                taskManagement.PrintEmployees();
                var emplId = int.Parse(Console.ReadLine());
                if (!taskManagement.ExistEmployee(emplId))
                    break;
                Console.WriteLine("Введите срок исполнения задачи(в днях)");
                var workDays = int.Parse(Console.ReadLine());
                Console.WriteLine("Оплата заказчиком отдельно : 1)да 2)нет");
                var billable = int.Parse(Console.ReadLine());
                bool bill;
                if (billable == 1)
                {
                    bill = true;
                }
                else
                {
                    bill = false;
                }
                taskManagement.AddNewTask(description, tNum, emplId, workDays, bill);
                break;
            }
        case 6:
            {
                Console.WriteLine("Введите ключ проекта:");
                var pk = int.Parse(Console.ReadLine());
                if (!taskManagement.ExistProject(pk))
                    break;
                taskManagement.PrintProjects(pk);
                Console.WriteLine($"стоимость проекта : {taskManagement.CalculateTotalCost()}");
                taskManagement.PrintTasks(pk);
                break;
            }
        //case 7:
        //    {
        //        Console.WriteLine("Добавление сотрудника : ");
        //        Console.WriteLine("Введите номер сотрудника : (если он занят, то номер будет выбран автоматически) /n");
        //        var eId = int.Parse(Console.ReadLine());
        //        Console.WriteLine("Введите ФИО сотрудника :");
        //        string eName = Console.ReadLine();
        //        Console.WriteLine("Введите должность сотрудника :");
        //        var eRat = int.Parse(Console.ReadLine());
        //        taskManagement.AddNewEmployee(eName, eId, eRat);
        //        break;
        //    }
        //case 8:
        //    {
        //        Console.WriteLine("Добавление нового клиента :");
        //        Console.WriteLine("Введите ФИО клиента : ");
        //        string fullName = Console.ReadLine();
        //        string name = fullName.Split()[0];
        //        Console.WriteLine("Введите электронную почту клиента :");
        //        string mail = Console.ReadLine();
        //        Console.WriteLine("Введите номер телефона клиента :");
        //        string phone = Console.ReadLine();
        //        taskManagement.AddNewCustomer(name, fullName, phone, mail);
        //        break;
        //    }
        case 7:
            {
                exit = true;
                break;
            }
        default:
            break;

    }

}

//DateTime inputDate()
//{
//    DateTime finishDate; 
//    string input;

//    do
//    { 
//        input = Console.ReadLine();
//    }
//    while (!DateTime.TryParseExact(input, "dd.MM.yyyy", null, DateTimeStyles.None, out finishDate));

//    return finishDate;
//}