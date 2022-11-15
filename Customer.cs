using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Customer : Person
    {
        public CreditCard CustomerCard { get; set; }

        public Customer(string name, int id, CreditCard customercard)
                : base(name, id)
        {
            CustomerCard = customercard;
        }

        //paramless ctor
        public Customer() : this("Unknown", 0, null) { }

        //copy ctor
        public Customer(Customer cust) : this(cust.Name, cust.ID, cust.CustomerCard)
        {

        }


        public override string ToString()
        {
            return  $"{Name}   ID#{ID}   {CustomerCard}";
        }
    }
}
