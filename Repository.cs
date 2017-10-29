using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StrataTest
{
    // we use the Repository as DataSource for the purpose of the test 
    // but can be easily converted to Database or anything else 
    // in that case all the ...Model classes have to be reviewied to read from a database 
    // the ...Action classes against wich an external programmer can use will remain the same 

    static class Repository
    {

        // config contains variables from web.comfig
        public static class Config
        {
            public static string SenderEmail { get; set; }
        }


        public static List<Discount> Discounts = new List<Discount>()
        {
            new Discount(){ CType = CustomerType.Standart , SpentMin = 0 , SpentMax = 499.99, Percentage= 0}, 
            new Discount(){ CType = CustomerType.Silver , SpentMin = 500 , SpentMax = 799.99, Percentage= 2},   
            new Discount(){ CType = CustomerType.Gold , SpentMin = 800 , SpentMax = double.MaxValue, Percentage= 3}   
        };

        public static List<Customer> Customers = new List<Customer>()
        {
            new Customer{ Name="Customer1", Address = "Address1", Email = "email1@mail.com"},
            new Customer{ Name="Customer2", Address = "Address2", Email = "email2@mail.com"},
            new Customer{ Name="Customer3", Address = "Address3", Email = "email3@mail.com"},
            new Customer{ Name="Customer4", Address = "Address4", Email = "email4@mail.com"},
            new Customer{ Name="Customer5", Address = "Address5", Email = "email5@mail.com"},
            new Customer{ Name="Customer6", Address = "Address6", Email = "email6@mail.com"},
            new Customer{ Name="Customer7", Address = "Address7", Email = "email7@mail.com"},
            new Customer{ Name="Customer8", Address = "Address8", Email = "email8@mail.com"},
            new Customer{ Name="Customer9", Address = "Address9", Email = "email9@mail.com"}
        };
        

        public static List<Product> Products = new List<Product>()
        {
            new Product{ Code = "PrCode1", Description="Produt 1" , UnitPrice = 1.00 },
            new Product{ Code = "PrCode2", Description="Produt 2" , UnitPrice = 2.00 },
            new Product{ Code = "PrCode3", Description="Produt 3" , UnitPrice = 3.00 },
            new Product{ Code = "PrCode4", Description="Produt 4" , UnitPrice = 4.00 },
            new Product{ Code = "PrCode5", Description="Produt 5" , UnitPrice = 5.00 },
        };

        public static List<Cart> Carts = new List<Cart>()
        {

        };


        public static List<Order> Orders = new List<Order>()
        {

        };

        public static List<OrderLine> OrderLines = new List<OrderLine>()
        {

        };



    }
}
