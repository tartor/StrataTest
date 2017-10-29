using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StrataTest
{

    public class Order
    {
        public string Id;
        public string Customer;
        public DateTime Date;
        public string Address;
        public double Amount;
    }

    internal class OrderModel
    {
        // return new order id
        public string Add(string sCustomer, string sAddress, double dAmount)
        {
            string sId = Guid.NewGuid().ToString();
            Order order = new Order() { Id = sId, Customer = sCustomer, Address = sAddress, Amount = dAmount, Date = DateTime.Now };

            Repository.Orders.Add(order);

            return sId;
        }

        public Order Get(string sId)
        {
            return
                (from o in Repository.Orders
                 where o.Id == sId
                 select o).SingleOrDefault();
        }

        public bool Delete(string sID)
        {
            return Repository.Orders.RemoveAll(o => o.Id == sID) != 0;
        }

    }

}
