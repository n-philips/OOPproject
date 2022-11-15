using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using System.IO;

namespace DAL
{
    public class ProductDAL
    {
        static List<Product> data = new List<Product>();

        //ctor
        public ProductDAL()
        {
            //InitializeList();
        }


        //initializes data list
        public static void InitializeList()
        {
            StreamReader reader = new StreamReader("ProductData.txt");
            string line;
            int index = 0;

            line = reader.ReadLine();

            using (reader)
            {
                while (line != null)
                {
                    var info = line.Split(' ');
                    int number = int.Parse(info[0]);
                    string name = info[1];
                    decimal cost = decimal.Parse(info[2]);
                    int amount = int.Parse(info[3]);
                    data.Add(new Product(number, name, cost, amount));
                    index++;
                    line = reader.ReadLine();
                }
            }
        }

        //Create method
        public void Create(Product newProduct)
        {
            bool alreadyExists = false;
            foreach(var product in data)
            {
                if(newProduct.ProductNumber == product.ProductNumber)
                {
                    alreadyExists = true;
                    break;
                }
            }

            if (alreadyExists == false)
            {
                data.Add(newProduct);
            }
            else if (alreadyExists == true)
            {
                throw new ItemAlreadyExistsException();
            }
        }

        //Read item method
        public Product ReadItem(int productNum)
        {
            bool itemFound = false;
            foreach (var product in data)
            {
                if (productNum == product.ProductNumber)
                {
                    itemFound = true;
                    Product prod = new Product(product);
                    return prod;
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
        public List<Product> ReadAll()
        {
            if (data.Count == 0)
            {
                throw new ItemNotFoundException("There are currently no products in stock.");
            }
            List<Product> productList = new List<Product>(data);
            //Product[] productArray = new Product[data.Count];
            //data.CopyTo(productArray);
            return productList;
        }

        //update method
        public void Update(Product UpdatedProduct)
        {
            bool itemFound = false;
            foreach (var product in data)
            {
                if (UpdatedProduct.ProductNumber == product.ProductNumber)
                {
                    data.Remove(product);
                    data.Add(UpdatedProduct);
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
        public void Delete(int productNum)
        {
            bool itemFound = false;
            foreach (var product in data)
            {
                if (productNum == product.ProductNumber)
                {
                    itemFound = true;
                    data.Remove(product);
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
            foreach (var product in data)
            {
                Console.WriteLine(product);
            }
        }
            


    }
}
