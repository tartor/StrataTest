using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StrataTest
{
    
    public class Customer
    {
        public string Name;
        public string Address;
        public string Email;
    }


    internal class CustomerModel
    {
        public bool Add(string sName, string sAddress, string sEmail)
        {
            if(Exists(sName))
                return false;

            Customer customer = new Customer() { Name = sName, Address = sAddress, Email = sEmail };
            Repository.Customers.Add(customer);
            return true;
        }

        public Customer Get(string sName)
        {
            return
                (from c in Repository.Customers
                 where c.Name == sName
                 select c).SingleOrDefault();
        }

        // for auhentication
        public Customer Get(string sName, string sEmail)
        {
            return
                (from c in Repository.Customers
                 where c.Name == sName && string.Compare(c.Email,sEmail,true) == 0
                 select c).SingleOrDefault();
        }

        public bool Exists(string sName)
        {
            return 
                (from c in Repository.Customers
                where c.Name == sName
                select c).Any();
        }

    }
}
