using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace DAL
{
    public class NotEnoughInStockException : Exception
    {
        public NotEnoughInStockException(Product prod)
            : base($"There are not enough {prod.ProductName} in stock.\nThe maximum number you can order is {prod.AmountInStock}")
        {

        }

        public NotEnoughInStockException(string message)
            : base(message)
        {

        }

        public NotEnoughInStockException(string message, Exception excep)
            : base(message, excep)
        {

        }
    }
}
