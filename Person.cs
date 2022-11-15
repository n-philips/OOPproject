using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Person
    {
        public string Name { get; set; }
        public int ID { get; set; }

        //ctor
        public Person(string name, int id)
        {
            Name = name;
            ID = id;
        }

        public Person() : this("Anonymous", 00000) { }

        public override string ToString()
        {
            return $"{Name} ID#{ID}";
        }
    }
}
