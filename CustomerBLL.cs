using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using DAL;

namespace BLL
{
    public class CustomerBLL
    {
        CustomerDAL custDal = new CustomerDAL();
        //create
        public void Create(Customer newcustomer)
        {
            try
            {
                custDal.Create(newcustomer);
            }
            catch
            {
                throw new ItemAlreadyExistsException();
            }
        }

        //read item
        public Customer ReadItem(int custId)
        {
            //ProductDAL prodDAL = new ProductDAL();
            try
            {
                return custDal.ReadItem(custId);
            }
            catch
            {
                throw new ItemNotFoundException();
            }
        }

        //read all
        public List<Customer> ReadAll()
        {
            try
            {
                return custDal.ReadAll();
            }
            catch
            {
                throw new ItemNotFoundException("There are currently no products in stock.");
            }
        }

        //update
        public void Update(Customer updatedCustomer)
        {
            try
            {
                custDal.Update(updatedCustomer);
            }
            catch
            {
                throw new ItemNotFoundException();
            }
        }

        //delete
        public void Delete(int productNum)
        {
            try
            {
                custDal.Delete(productNum);
            }
            catch
            {
                throw new ItemNotFoundException();
            }
        }

    }
}
