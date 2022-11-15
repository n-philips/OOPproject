using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ItemNotFoundException : Exception
    {
        public ItemNotFoundException()
            : base ("The item you are searching for is not recorded.")
        {

        }

        public ItemNotFoundException(string message)
            : base (message)
        {

        }

        public ItemNotFoundException(string message, Exception excep)
            : base(message, excep)
        {

        }
    }
}
