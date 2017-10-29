using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StrataTest
{

    interface ICourierHandler
    {
        bool Deliver(Order order,IEnumerable<OrderLine> orderLines);

    }

    class CourierHandler1 : ICourierHandler
    {
        public bool Deliver(Order order,IEnumerable<OrderLine> orderLines)
        {
            // here we engage with the courier notification system

            return true;
        }
    }

    class CourierHandler2 : ICourierHandler
    {
        public bool Deliver(Order order,IEnumerable<OrderLine> orderLines)
        {
            // here we engage with the courier notification system

            return true;
        }
    }


}
