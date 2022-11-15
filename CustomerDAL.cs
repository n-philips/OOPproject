using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using System.IO;

namespace DAL
{
    public class CustomerDAL
    {
        static List<Customer> customers = new List<Customer>();

            //ctor
            public CustomerDAL()
            {
                //InitializeList();
            }


            //initializes data list
            public static void InitializeList()
            {
                StreamReader reader = new StreamReader("CustomerData.txt");
                string line;
                int index = 0;

                line = reader.ReadLine();

                using (reader)
                {
                    while (line != null)
                    {
                        var info = line.Split(' ');
                        int id = int.Parse(info[0]);
                        string name = info[1];
                        string cardnum = info[2];
                        int year = int.Parse(info[3]);
                        int month = int.Parse(info[4]);
                        string cvv = info[5];
                        decimal charges = int.Parse(info[6]);
                        Date expdate = new Date(year, month);
                        CreditCard crdit = new CreditCard(name, cardnum, expdate, cvv, charges);
                        customers.Add(new Customer(name, id, crdit));
                        index++;
                        line = reader.ReadLine();
                    }
                }
            }

            //Create method
            public void Create(Customer newCustomer)
            {
                bool alreadyExists = false;
                foreach (var cust in customers)
                {
                    if (newCustomer.ID == cust.ID)
                    {
                        alreadyExists = true;
                        break;
                    }
                }

                if (alreadyExists == false)
                {
                    Customer copytoAdd = new Customer(newCustomer);
                    customers.Add(copytoAdd);
                }
                else
                {
                    throw new ItemAlreadyExistsException();
                }
            }

            //Read item method
            public Customer ReadItem(int id)
            {
                bool itemFound = false;
                foreach (var cust in customers)
                {
                    if (id == cust.ID)
                    {
                        itemFound = true;
                        Customer customer = new Customer(cust);
                        return customer;
                    }
                }

                if (itemFound == false)
                {
                    //if it reaches this code, there were no matches, therefore...
                    throw new ItemNotFoundException();
                }

                //this code will never be reached we are just making the compiler happy
                return null;
            }

            //Read all method
            public List<Customer> ReadAll()
            {
                if (customers.Count == 0)
                {
                    throw new ItemNotFoundException("There are currently no existing customers.");
                }
                List<Customer> customerList = new List<Customer>(customers);
                //Customer[] customerArray = new Customer[customers.Count];
                //customers.CopyTo(customerList);
                return customerList;
            }

            //update method
            public void Update(Customer UpdateCustomer)
            {
                bool itemFound = false;
                foreach (var cust in customers)
                {
                    if (UpdateCustomer.ID == cust.ID)
                    {
                        customers.Remove(cust);
                        Customer updateCustomerCopy = new Customer(UpdateCustomer);
                        customers.Add(updateCustomerCopy);
                        itemFound = true;
                        break;
                    }
                }

                if (itemFound == false)
                {
                    //if it reaches this code, there were no matches, therefore...
                    throw new ItemNotFoundException();
                }
            }

            //delete method
            public void Delete(int ID)
            {
                bool itemFound = false;
                foreach (var Customer in customers)
                {
                    if (ID == Customer.ID)
                    {
                        itemFound = true;
                        customers.Remove(Customer);
                        break;
                    }
                }

                if (itemFound == false)
                {
                    //if it reaches this code, there were no matches, therefore...
                    throw new ItemNotFoundException();
                }
            }

            //test if it added by displaying list
            public void Print()
            {
                Console.WriteLine("\nUpdated List:");
                foreach (var Customers in customers)
                {
                    Console.WriteLine(Customers);
                }
            }
        }
}
