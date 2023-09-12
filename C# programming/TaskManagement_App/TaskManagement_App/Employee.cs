using System;
namespace TaskManagement_App
{
	public class Employee
	{
		public string FullName { get; set; }    // ФИО сторудника
		public int Number { get; set; }         // табельный номер сотрудника
		public int Rating { get; set; }     // должность сотрудника (от 1 до 5)
        public Position Position { get; set; }
        public double HourlyRate
        {
            get { return Position.BaseHourlyRate * (1 + (Rating - 1) * 0.05); }
        }

        //public Employee(Position pos, string emplName, int emplNumber, int emplRating)
        //{
        //    Position = pos;
        //    FullName = emplName;
        //    Number = emplNumber;
        //    Rating = emplRating;
        //}

        public override string ToString()
        {
            return $"Сотрудник {Number} - ФИО : {FullName}, должность - {Rating}";
        }
    }
}

