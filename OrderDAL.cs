using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using System.IO;

namespace DAL
{
    public class OrderDAL
    {
        static List<Order> data = new List<Order>();

        //ctor
        public OrderDAL()
        {
            //InitializeList();
        }


        //initializes data list
        public static void InitializeList()
        {
            StreamReader reader = new StreamReader("OrderData.txt");
            string line;
            int index = 0;

            line = reader.ReadLine();

            using (reader)
            {
                while (line != null)
                {
                    var info = line.Split(' ');
                    //int ordernum = int.Parse(info[0]);
                    int productnum = int.Parse(info[0]);
                    int customerid = int.Parse(info[1]);
                    int orderquantity = int.Parse(info[2]);
                    data.Add(new Order(productnum, customerid, orderquantity));
                    Order.NumOfOrders++;
                    index++;
                    line = reader.ReadLine();
                }
            }
        }

        public void Create(Order newOrder)
        {
            bool alreadyExists = false;
            foreach (var ord in data)
            {
                if (newOrder.OrderNumber == ord.OrderNumber)
                {
                    alreadyExists = true;
                    break;
                }
            }
            data.Add(newOrder);
            /*if (alreadyExists == false)
            {
                data.Add(newOrder);
            }
            else
            {
                throw new ItemAlreadyExistsException();
            }*/
        }

        //Read item method
        public List<Order> ReadItem(int ordernum)
        {
            bool itemFound = false;
            List<Order> orders = new List<Order>();
            foreach (var ord in data)
            {
                if (ordernum == ord.OrderNumber)
                {
                    itemFound = true;

                        Order order = new Order(ord);
                        orders.Add(order);
                }
            }

            if (itemFound == false)
            {
                //if it reaches this code, there were no matches, therefore...
                throw new ItemNotFoundException();
            }
            else
            {
                return orders;
            }
        }

        //update method
        public void Update(Order UpdateOrder)
        {
            //bool itemFound = false;
            /*foreach (var ord in data)
            {
                if (UpdateOrder.OrderNumber == ord.OrderNumber)
                {
                    Delete(ord.OrderNumber);
                    *//*data.Remove(ord);
                    data.Add(UpdateOrder);
                    itemFound = true;
                    //break;*//*
                }
            }*/

            Create(UpdateOrder);

            /*if (itemFound == false)
            {
                //if it reaches this code, there were no matches, therefore...
                throw new ItemNotFoundException();
            }*/
        }

        public void Write()
        {
            foreach (Order ord in data)
            {
                Console.WriteLine(ord);
            }
        }

        //Read all method
        public List<Order> ReadAll()
        {
            if (data.Count == 0)
            {
                throw new ItemNotFoundException("There are currently no existing customers.");
            }
            List<Order> orderList = new List<Order>(data);
            //Order [] orderArray = new Order[data.Count];
            //data.CopyTo(orderArray);
            return orderList;
        }

        //delete method
        public void Delete(int orderNum)
        {
            bool itemFound = false;
            /*bool done = false;
            while (done != true)
            {
                foreach (var ord in data)
                {
                    if (orderNum == ord.OrderNumber)
                    {
                        itemFound = true;
                        data.Remove(ord);
                        break;
                    }
                }
                done = true;
            }*/

            foreach (var order in data)
            {
                if (orderNum == order.OrderNumber)
                {
                    itemFound = true;
                    data.Remove(order);
                    break;
                }
            }


            if (itemFound == false)
            {
                //if it reaches this code, there were no matches, therefore...
                throw new ItemNotFoundException();
            }
        }
    }
}
