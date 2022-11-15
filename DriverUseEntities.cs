using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using DAL;
using System.IO;
using BLL;

namespace UseEntities
{
    class DriverUseEntities
    {
        static void Main(string[] args)
        {
            //int index = 0;

            /*Person person1 = new Person();
            Person person2 = new Person();
            Person person3 = new Person();
            Person person4 = new Person();
            Person person5 = new Person();
            Person person6 = new Person();
            Person person7 = new Person();
            Person person8 = new Person();*/
            /*Product product1 = new Product();

            Person[] people = new Person[10];

            //read in 8 people from text file
            StreamReader reader = new StreamReader("people.txt");

            using (reader)
            {
                while (index < 8)
                {
                    people[index] = new Person(reader.ReadLine(), int.Parse(reader.ReadLine()));
                    index++;
                }
            }*/

            /*//print array
            for (int i = 0; i < people.Length; i++)
            {
                Console.WriteLine(people[i]);
            }

            //create expiration date for credit card
            Date expdate = new Date(09, 23);

            //create credit card to give customer
            CreditCard buyalot = new CreditCard("Yachna's husband", "7895136798542168", expdate, 500.01m);

            //test customer
            Customer maalotstudent = new Customer("Yachna Dvoshe", 846826576, buyalot);
            Console.WriteLine(maalotstudent);

            Console.WriteLine(maalotstudent.CustomerCard);

            //test employee
            Employee neveworker = new Employee("Solomon", 784595541, 1500);
            Console.WriteLine(neveworker);

            //test manager
            Manager eli = new Manager("Eli", 754268765, 800, 17);
            Console.WriteLine(eli);

            //test sales rep
            SalesRep dudi = new SalesRep("Dudi", 784656925, 70, 5);
            Console.WriteLine(dudi);

            //test ProductDAL
            ProductDAL pp = new ProductDAL();

            //test create productDAL method
            Product test = new Product(74533, "foodfortest", 10, 10);
            pp.Create(test);
            //pp.Create(test); //testing exception

            
            //test delete method
            pp.Delete(78945);
            //pp.Delete(00000);//test exception*/

            /* ProductBLL BLLtest = new ProductBLL();
             Product test2 = new Product(98765, "new tester", 10, 50);

             //test BLL create method
             BLLtest.Create(test2);

             //test BLL read method
             Console.WriteLine("Item we read: " + BLLtest.ReadItem(98765)+"\n");

             //test BLL readall method
             foreach(var item in BLLtest.ReadAll())
             {
                 Console.WriteLine(item);
             }

             Product test3 = new Product(98765, "newtester", 10, 0);

             //test BLL update
             BLLtest.Update(test3);

             //test BLL readall method
             Console.WriteLine("Updated list:");
             foreach (var item in BLLtest.ReadAll())
             {
                 Console.WriteLine(item);
             }

             //test BLL delete
             BLLtest.Delete(99987);
             Console.WriteLine("Deleted hamburgers from list:");
             foreach (var item in BLLtest.ReadAll())
             {
                 Console.WriteLine(item);
             }*/

            /*CustomerBLL testCustomer = new CustomerBLL();
            Date expirationDate = new Date(5, 20);
            CreditCard cred = new CreditCard("MyName", "123456789", expirationDate, "222", 678.90M);

            //test BLL readall method
            Customer[] readall = testCustomer.ReadAll();
            foreach (var customer in readall)
            {
                Console.WriteLine(customer);
            }

            //test new
            Customer blltest = new Customer("MyName", 678, cred);
            //testCustomer.Create(blltest);

            //print to see if new added
            Console.WriteLine("\nUpdated List:");
            foreach (var item in testCustomer.ReadAll())
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();*/

            //test read
            //Console.WriteLine("\n" + testCustomer.ReadItem(0));

            //test update
            //testCustomer.Update(blltest);
            //Console.WriteLine("\n" + testCustomer.ReadItem(890) + "\n");

            /* testCustomer.Delete(234);
             readall = testCustomer.ReadAll();
             foreach (var customer in readall)
             {
                 Console.WriteLine(customer);
             }*/

            //Order food = new Order(111, 11111, 100, 2);

            //Console.WriteLine(food);

            //OrderDAL order = new OrderDAL();
            //Console.WriteLine(Environment.CurrentDirectory);


            //testing OrderBLL ReadAll() 

            ProductDAL.InitializeList();
            CustomerDAL.InitializeList();
            OrderDAL.InitializeList();

            Order ord = new Order(44444, 100, 3);

            OrderDAL orddal = new OrderDAL();
            OrderBll ordBLL = new OrderBll();

            /*foreach (var data in orddal.ReadAll())
            {
                Console.WriteLine(data);
            }*/

            /*OrderDAL orddal2 = new OrderDAL();
            Console.WriteLine("After new:");
            foreach (var data in orddal.ReadAll())
            {
                Console.WriteLine(data);
            }*/

            ordBLL.Create(ord);

            Console.WriteLine("After adding:");
            foreach (var data in orddal.ReadAll())
            {
                Console.WriteLine(data);
            }

            ordBLL.Delete(1);

            Console.WriteLine("After deleting:");
            foreach (var data in orddal.ReadAll())
            {
                Console.WriteLine(data);
            }
            Console.WriteLine("Testing read: " + ordBLL.ReadItem(2));


            Order ordUp = new Order(2, 11111, 200, 23);
            ordBLL.Update(ordUp);
            Console.WriteLine("Testing update: " + ordBLL.ReadItem(2));

            Console.ReadLine();
        }
    }
}

