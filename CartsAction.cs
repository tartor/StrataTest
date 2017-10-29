using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StrataTest
{
    class CartsAction : AuthenticatedAction
    {
        public bool AddProduct(string sProductCode, int iQuantity)
        {
            ProductModel productModel = new ProductModel();
            Product product = productModel.Get(sProductCode);

            if (product == null)
                return false;

            CartModel cartModel = new CartModel();
            return cartModel.Add(base.Customer.Name, sProductCode, iQuantity, product.UnitPrice);
        }

        public bool UpdateProduct(string sProductCode, int iQuantity)
        {
            CartModel cartModel = new CartModel();
            return cartModel.SetQuantity(base.Customer.Name, sProductCode, iQuantity);
        }

        public bool DeleteProduct(string sProductCode)
        {
            CartModel cartModel = new CartModel();
            return cartModel.Delete(base.Customer.Name,sProductCode);
        }

        public IEnumerable<Cart> Review()
        {
            CartModel cartModel = new CartModel();
            return cartModel.Get(base.Customer.Name);
        }


    }
}
