using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace StrataTest
{
    class CustomerNoAuthenticatedException : Exception
    {
    }

    // every class derived from AuthenticatedAction can be used only if user is logged in 
    class AuthenticatedAction
    {
        Customer customer = null;
        public AuthenticatedAction()
        {
            //if user is not authenticated throw exception
            customer = HttpContext.Current.Session["customer"] as Customer;

            if (customer == null)
            {
                throw new CustomerNoAuthenticatedException();
            }
        }


        // give acces to the authenticated customer
        protected Customer Customer
        {
            get { return customer; }
        }

    }
}
