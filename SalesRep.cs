using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class SalesRep : Employee
    {
        public int CommissionRate { get; set; }

        public SalesRep(string name, int id, int salary, int commissionrate)
            : base(name, id, salary)
        {
            this.CommissionRate = commissionrate;
        }

        public override string ToString()
        {
            return $"{Name}   ID#{ID}   Salary: {Salary}, Commission rate: {CommissionRate}%";
        }
    }
}
