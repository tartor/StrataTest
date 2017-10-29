using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StrataTest
{
    public class OrderLine
    {
        public string OrderId;
        public string ProductCode;
        public int Quantity;
        public double UnitPrice;
    }


    internal class OrderLinesModel
    {
        public bool Add(string sOrderId, string sProductCode, int iQuantity, double dUnitPrice)
        {
            if (iQuantity <= 0)
                return false;

            OrderLine orderLine = new OrderLine() { OrderId = sOrderId, ProductCode = sProductCode, Quantity = iQuantity, UnitPrice = dUnitPrice };
            Repository.OrderLines.Add(orderLine);

            return true;
        }

        public IEnumerable<OrderLine> GetAll(string OrderId)
        {
            return
                (from ol in Repository.OrderLines
                 where ol.OrderId == OrderId
                 select ol);
        }

        public bool Delete(string OrderId)
        {
            return Repository.OrderLines.RemoveAll(ol => ol.OrderId == OrderId) != 0;
        }

    }
}
