using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ItemAlreadyExistsException : Exception
    {
        public ItemAlreadyExistsException()
            : base("The item you are trying to add already exists.")
        {

        }

        public ItemAlreadyExistsException(string message)
            : base(message)
        {

        }

        public ItemAlreadyExistsException(string message, Exception excep)
            : base(message, excep)
        {

        }
    }
}
