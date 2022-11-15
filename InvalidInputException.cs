using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class InvalidInputException : Exception
    {
        public InvalidInputException()
            : base("Invalid input")
        {

        }

        public InvalidInputException(string message)
            : base(message)
        {

        }

        public InvalidInputException(string message, Exception excep)
            : base(message, excep)
        {

        }
    }
}
