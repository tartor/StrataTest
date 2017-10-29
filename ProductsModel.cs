using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StrataTest
{
    public class Product
    {
        public string Code;
        public string Description;
        public double UnitPrice;
    }


    internal class ProductModel
    {
        public Product Get(string sCode)
        {
            Product product =
                (from p in Repository.Products
                 where p.Code == sCode
                 select p).SingleOrDefault();

            return product;

        }

        public IEnumerable<Product> GetAll()
        {
            return Repository.Products;
        }
    }

}
