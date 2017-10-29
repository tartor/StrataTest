using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StrataTest
{

    public interface IPaymentHandler
    {
        bool MakePayment(string sCustomer,double Amount);
    }


    class PaymentAction1 : IPaymentHandler
    {

        public bool MakePayment(string sCustomer,double Amount)
        {
            // here we engage with the payment system

            return true;
        }
    }

    class PaymentAction2 : IPaymentHandler
    {
        public bool MakePayment(string sCustomer,double Amount)
        {
            // here we engage with the payment system

            return true;
        }
    }

}
