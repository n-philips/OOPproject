using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using DAL;

namespace BLL
{
    public class OrderBll
    {
        static List<Order> data = new List<Order>();
        OrderDAL ordDAL = new OrderDAL();
        ProductDAL prodDAL = new ProductDAL();
        CustomerBLL custBLL = new CustomerBLL();
        ProductBLL prodBLL = new ProductBLL();

        //create
        public void Create(Order newOrder)
        {
            if (CustomerExists(newOrder.CustomerID) == true && ProductExists(newOrder.ProductNumber) == true
                    && HaveEnough(newOrder.ProductNumber, newOrder.OrderQuantity) == true)
            {
                try
                {
                    ordDAL.Create(newOrder);
                }
                catch
                {
                    throw new ItemAlreadyExistsException();
                }

                Product toUpdate = prodDAL.ReadItem(newOrder.ProductNumber);
                prodDAL.Update(toUpdate);
            }
        }

        public List<Order> ReadAll()
        {
            try
            {
                return ordDAL.ReadAll();
            }
            catch
            {
                throw new ItemNotFoundException("There are currently no products in stock.");
            }
        }


        //read item
        public List<Order> ReadItem(int ordId)
        {
            try
            {
                return ordDAL.ReadItem(ordId);
            }
            catch
            {
                throw new ItemNotFoundException();
            }
        }

        #region Update
        public void Update(List<Order> updateOrder)
        {
            /*try
            {
                ordDAL.Update(updateOrder);
            }
            catch
            {
                throw new ItemNotFoundException();
            }*/
            try
            {
                
                //List<Order> toUpdate = this.ReadItem(orderNumber);
                    /*foreach(var oldOrder in oldversion)
                    {
                        if(oldOrder.ProductNumber == ord.ProductNumber)
                        {
                            Order 
                            ordDAL.Update()
                        }
                    }*/
                    List<Order> oldversion = ReadItem(updateOrder[0].OrderNumber);
                ordDAL.Delete(oldversion[0].OrderNumber);
                /*while (oldversion.Count != 0)
                {
                    foreach (var ord in oldversion)
                    {
                        int updateStock = oldversion[0].OrderQuantity - ord.OrderQuantity;
                        Product toUpdate = prodBLL.ReadItem(ord.ProductNumber);
                        toUpdate.AmountInStock += updateStock;
                        prodDAL.Update(toUpdate);
                        oldversion.Remove(ord);
                        break;
                    }
                }*/
                
                foreach(var order in updateOrder)
                {
                    ordDAL.Update(order);
                }


            }
            catch
            {
                throw new ItemNotFoundException();
            }
        }


        #endregion


        //delete
        public void Delete(int orderNumber)
        {
            try
            {
                List<Order> toDelete = this.ReadItem(orderNumber);
                foreach(var ord in toDelete)
                {
                    Product toUpdate = prodBLL.ReadItem(ord.ProductNumber);
                    toUpdate.AmountInStock += ord.OrderQuantity;
                    prodDAL.Update(toUpdate);
                    ordDAL.Delete(orderNumber);
                }
            }
            catch
            {
                throw new ItemNotFoundException();
            }
        }

        public bool CustomerExists(int custID)
        {
            try
            {
                custBLL.ReadItem(custID);
                return true;
            }
            catch
            {
                throw new ItemNotFoundException("The customer you have selected does not exist. Please check the ID number and try again");
            }
        }

        public bool ProductExists(int prodNum)
        {
            try
            {
                prodBLL.ReadItem(prodNum);
                return true;
            }
            catch
            {
                throw new ItemNotFoundException("The product you have selected does not exist. Please check the ID number and try again");
            }
        }

        public bool HaveEnough(int prodnum, int amountOrdered)
        {
            Product prod = prodBLL.ReadItem(prodnum);
            if (prod.AmountInStock >= amountOrdered)
            {
                return true;
            }
            else
            {
                throw new NotEnoughInStockException(prod);
            }
        }
    }
}
