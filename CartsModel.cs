using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StrataTest
{
    public class Cart
    {
        public string Customer;
        public string ProductCode;
        public int Quantity;
        public double UnitPrice;
    }

    internal class CartModel
    {
        public bool Add(string sCustomer, string sProductCode, int iQuantity, double dPrice)
        {
            if(iQuantity <= 0)
                return false;

            Cart cart =
                (from c in Repository.Carts
                 where c.Customer == sCustomer && c.ProductCode == sProductCode
                 select c).SingleOrDefault();

            if (cart == null)
            {
                // add
                cart = new Cart() { Customer = sCustomer, ProductCode = sProductCode, Quantity = iQuantity, UnitPrice = dPrice };
                Repository.Carts.Add(cart);
                return true;
            }

            //update
            cart.Quantity += iQuantity;
            System.Diagnostics.Debug.Assert(cart.UnitPrice == dPrice);

            return true;

        }

        public bool Delete(string sCustomer)
        {
            return Repository.Carts.RemoveAll(c => c.Customer == sCustomer) > 0;
        }

        public bool Delete(string sCustomer, string sProductCode)
        {

            return Repository.Carts.RemoveAll( c => c.Customer == sCustomer && c.ProductCode == sProductCode  ) > 0;

        }

        public bool SetQuantity(string sCustomer, string sProductCode, int iQuantity)
        {
            if (iQuantity <= 0)
                return false;

            Cart cart =
                (from c in Repository.Carts
                where c.Customer == sCustomer && c.ProductCode == sProductCode
                 select c).SingleOrDefault();

            if (cart == null)
                return false;

            cart.Quantity = iQuantity;
            return true;
        }

        public IEnumerable<Cart> Get(string sCustomer)
        {
            return 
                from c in Repository.Carts
                 where c.Customer == sCustomer
                 select c;

        }
    }

}
