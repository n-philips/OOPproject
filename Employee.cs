using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Employee : Person
    {
        public double Salary { get; set; }

        public Employee(string name, int id, double salary)
            : base(name, id)
        {
            this.Salary = salary;
        }

        public override string ToString()
        {
            return $"{Name}   ID#{ID}   Salary: {Salary:C}";
        }
    }
}
