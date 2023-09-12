using System;
using System.Threading.Tasks;

namespace TaskManagement_App
{
	public class Project
	{
		public int InitialCost { get; set; }    // бюджет проекта
		public string Title { get; set; }       // название проекта
		public int Key { get; set; }            // ключ проекта
        public Task Task { get; set; }
        public Position Position { get; set; } 
        public Customer Customer { get; set; }
        private double AmountCost { get; set; }    // итоговая стоимость проекта

        public Project(Customer cust, Task task,int initCost, string projName, int projKey)
        {
            Customer = cust;
            Task = task;
            Title = projName;
            Key = projKey;
            InitialCost = initCost;
        }

        public override string ToString()
        {
            return $"Название проекта : {Title}, бюджет проекта - {InitialCost}₽, ключ проекта - {Key}, владелец - {Customer.ContactPerson}";
        }

        
    }
}

