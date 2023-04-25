using System;
namespace LINQ
{
    internal class StudentMarks
    {
        /// <summary>
        /// Номер класса учащегося
        /// </summary>
        public int Class { get; set; }
        /// <summary>
        /// Фамилия учащегося
        /// </summary>
        public string Surname { get; set; }
        /// <summary>
        /// Инициалы учащегося
        /// </summary>
        public string Initials { get; set; }
        /// <summary>
        /// Название предмета
        /// </summary>
        public string SubjectName { get; set; }
        /// <summary>
        /// Оценка
        /// </summary>
        public double Mark { get; set; }
    }
}

