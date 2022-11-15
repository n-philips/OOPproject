using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Product
    {
        public int ProductNumber { get; set; }
        public string ProductName { get; set; }
        public decimal CostPerUnit { get; set; }
        public int AmountInStock { get; set; }

        //ctor initializes product number, name, and cost per unit
        public Product(int productnumber, string productname, decimal costperunit, int amountinstock)
        {
            ProductNumber = productnumber;
            ProductName = productname;
            CostPerUnit = costperunit;
            AmountInStock = amountinstock;
        }

        //copy ctor
        public Product(Product prod) : this(prod.ProductNumber, prod.ProductName, prod.CostPerUnit, prod.AmountInStock)
        {

        }

        //paramless ctor initializes number, name, and cost per unit
        public Product() : this(00000, "XXXXXXX", 0, 0) { }

        public override string ToString()
        {
            return $"{ProductNumber}    {ProductName}";
        }
    }
}
