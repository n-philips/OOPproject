using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using DAL;

namespace BLL
{
    public class ProductBLL
    {
        ProductDAL prodDAL = new ProductDAL();

        //create
        public void Create(Product newProduct)
        {
            //ProductDAL prodDAL = new ProductDAL();
            try
            {
                prodDAL.Create(newProduct);
            }
            catch
            {
                throw new ItemAlreadyExistsException();
            }
        }

        //read item
        public Product ReadItem(int productNum)
        {
            //ProductDAL prodDAL = new ProductDAL();
            try
            {
                return prodDAL.ReadItem(productNum);
            }
            catch
            {
                throw new ItemNotFoundException();
            }
        }

        //read all
        public List<Product> ReadAll()
        {
            try
            {
                return prodDAL.ReadAll();
            }
            catch
            {
                throw new ItemNotFoundException("There are currently no products in stock.");
            }
        }

        //update
        public void Update(Product updatedProduct)
        {
            try
            {
                prodDAL.Update(updatedProduct);
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
                prodDAL.Delete(productNum);
            }
            catch
            {
                throw new ItemNotFoundException();
            }
        }

    }
}
