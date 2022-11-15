using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_Layer
{
    class NullInputException: Exception
    {
        public NullInputException()
            : base("Please enter the number of the item you would like to view")
        {

        }

        public NullInputException(string message)
            : base(message)
        {

        }

        public NullInputException(string message, Exception excep)
            : base(message, excep)
        {

        }
    }
}
