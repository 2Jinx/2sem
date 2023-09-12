using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqApp
{
    internal class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Group { get; set; }

        public int Semestr { get; set; }

        public List<int> Marks { get; set; }

        public override string ToString()
        {
            return $"Student:{Id} {Name} {Group} {Marks.Count}";
        }
    }
}