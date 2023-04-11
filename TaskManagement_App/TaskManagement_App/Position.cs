using System;
namespace TaskManagement_App
{
	public class Position
	{
		public int Code { get; set; }           // шифр должности
		public string Name { get; set; }        // название должности
		public int BaseHourlyRate { get; set; } // базовая почасовая ставка
		public double HourlyRate { get; set; }     // стоимость часа работ сотрудника

        public double CountSalary()
		{
			return BaseHourlyRate * HourlyRate;
		}
        public override string ToString()
        {
			return $"Должность {Code} : {Name}, базовая почасовая ставка - {BaseHourlyRate}, стоимость часа работ - {HourlyRate} ₽/час";
        }
    }
}

