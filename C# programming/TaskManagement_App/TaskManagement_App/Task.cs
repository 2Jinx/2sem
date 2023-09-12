using System;

namespace TaskManagement_App
{
	public class Task
	{
		public decimal Number { get; set; }       // номер задачи
		public string Description { get; set; }   // описание задачи
		public DateTime CloseDate { get; set; }   // дата завершения задачи
		public int DueDate { get; set; }          // срок исполнения задачи
		public int HoursSpent { get; set; }       // время (в часах), потраченное на выполенение задачи
		public bool Billable { get; set; }        // параметр "Отдельно оплачивается заказчиком"
		public Employee Employee { get; set; }


		public Task(Employee empl,int taskNum, string descript, int countWorkDays, bool isBill)
		{
			Employee = empl;
			Number = taskNum;
			Description = descript;
			DueDate = countWorkDays;
			Billable = isBill;
			HoursSpent = 8 * countWorkDays;
			CloseDate = DateTime.Now.AddDays(countWorkDays);
		}

		public override string ToString()
        {
			if (Billable)
			{
				return $"Задача {Number} : сотрудник - {Employee.FullName}, описание - {Description}, дата завершения задачи - {CloseDate}, " +
					$"срок исполнения(в днях) - {DueDate}, время(в часах), потраченное на выполнение - {HoursSpent}, " +
					$"| ОПЛАЧИВАЕТСЯ ЗАКАЗЧИКОМ ОТДЕЛЬНО ! | ";
			}
            return $"Задача {Number} : сотрудник - {Employee.FullName}, описание - {Description}, дата завершения задачи - {CloseDate}, " +
                    $"срок исполнения - {DueDate}, время(в часах), потраченное на выполнение - {HoursSpent}, " +
                    $"| ОПЛАТА ВХОДИТ В СТОИМОСТЬ ПРОЕКТА ! | ";
        }
    }
}

