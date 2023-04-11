using System;
namespace TaskManagement_App
{
	public class Customer
	{
		public string Name { get; set; }              // имя
		public string ContactEmail { get; set; }      // электронная почта клиента
		public string ContactPerson { get; set; }     // ФИО клиента
		public string ContactPhone { get; set; }      // номер телефона клиента
		public Project Project { get; set; }

		//public Customer(Project proj, string name, string email, string fio, string phoneNum)
		//{
		//	Project = proj;
		//	ContactEmail = email;
		//	ContactPerson = fio;
		//	ContactPhone = phoneNum;
		//}
        public override string ToString()
        {
			return $"Клиент {Name} - ФИО : {ContactPerson} , телефон - {ContactPhone}, электронная почта - {ContactEmail}";
        }
    }
}

