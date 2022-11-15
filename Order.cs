using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Order
    {
        public int OrderNumber { get; set; }
        public int ProductNumber { get; set; }
        public int CustomerID { get; set; }
        public int OrderQuantity { get; set; }
        public DateTime TimeOfOrder { get; set; }
        public static int NumOfOrders = 1;

        public Order(int productnumber, int customerid, int orderquantity)
        {
            this.OrderNumber = NumOfOrders;
            this.ProductNumber = productnumber;
            this.CustomerID = customerid;
            this.OrderQuantity = orderquantity;
            this.TimeOfOrder = DateTime.Now;
        }

        public Order(int ordernumber, int productnumber, int customerid, int orderquantity)
        {
            this.OrderNumber = ordernumber;
            this.ProductNumber = productnumber;
            this.CustomerID = customerid;
            this.OrderQuantity = orderquantity;
            this.TimeOfOrder = DateTime.Now;
        }

        //copy ctor
        public Order(Order ord)
        {
            ProductNumber = ord.ProductNumber;
            CustomerID = ord.CustomerID;
            OrderQuantity = ord.OrderQuantity;
            OrderNumber = ord.OrderNumber;
            TimeOfOrder = ord.TimeOfOrder;
        }

        public override string ToString()
        {
            return $"Order number: {OrderNumber} - Prod number: {ProductNumber} - " +
                $"Cust id: {CustomerID} - Quantity: {OrderQuantity} - Time: {TimeOfOrder}";
        }


    }
}
