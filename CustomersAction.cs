using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace StrataTest
{
    class CustomersAction
    {

        public bool Register(string Customer,string Address, string Email)
        {
            if (string.IsNullOrWhiteSpace(Customer))
                return false;
            if (string.IsNullOrWhiteSpace(Address))
                return false;
            if (string.IsNullOrWhiteSpace(Email))
                return false;

            CustomerModel customerModel = new CustomerModel();
            return customerModel.Add(Customer, Address,Email);
        }


        public bool Login(string Customer, string Email)
        {
            // we use customer id and email to authenticate
            CustomerModel customerModel = new CustomerModel();
            Customer customer = customerModel.Get(Customer, Email);
            if (customerModel == null)
                return false;

            HttpContext.Current.Session["customer"] = customer;
            return true;
        }

        public bool Logout()
        {
            HttpContext.Current.Session["customer"] = null;
            return true;
        }
    }
}
