using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StrataTest
{

    public enum CustomerType
    {
        Standart,
        Silver,
        Gold
    }

    public class Discount
    {
        public CustomerType CType;
        public double SpentMin;
        public double SpentMax;
        public double Percentage;
    }

    internal class DiscountModel
    {
        public Discount Get(string sCustomer)
        {

            DateTime dt12 = DateTime.Now.AddYears(-1);
            double dAmount12 = Repository.Orders.Where(o => o.Date >= dt12).Sum(o => o.Amount);

            return
                (from d in Repository.Discounts
                 where d.SpentMin <= dAmount12 && dAmount12 <= d.SpentMin
                 select d
                ).SingleOrDefault();
        }
    }
}
