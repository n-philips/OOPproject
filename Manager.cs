using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Manager : Employee
    {
        public int Vetek { get; set; }

        public Manager(string name, int id, int salary, int vetek)
            : base(name, id, salary)
        {
            this.Vetek = vetek;
        }

        public override string ToString()
        {
            return $"{Name}   ID#{ID}   Salary: {Salary:C}   Vetek: {Vetek}";
        }
    }
}
