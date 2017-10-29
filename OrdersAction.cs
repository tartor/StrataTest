using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StrataTest
{
    class OrdersAction : AuthenticatedAction
    {
        //supply the actual class that will handle the payment and courier 
        // example calls 
        // Create(new PaymentHandler1(), new CourierHandler1())
        // Create(new PaymentHandler2(), new CourierHandler2())
        // the right class can be chossen from the caller based on config string or defined web provider class

        public bool Create(IPaymentHandler paymentHandler, ICourierHandler courierHandler)
        {
            if (paymentHandler == null || courierHandler == null)
                return false;

            // check if the customer has products in the cart
            CartModel cartModel = new CartModel();
            IEnumerable<Cart> carts = cartModel.Get(base.Customer.Name);

            if (carts == null && carts.Count() <= 0)
                return false;

            // calculate the amount have to pay 
            double dAmount = carts.Sum( c => c.Quantity * c.UnitPrice );
            if (dAmount <=0 )
                return false;

            // check for discount
            DiscountModel discountModel = new DiscountModel();
            Discount discount = discountModel.Get(base.Customer.Name);
            if (discount != null && discount.Percentage != 0)
            {
                dAmount -= Math.Round((dAmount * discount.Percentage) / 100,2);
                System.Diagnostics.Debug.Assert(dAmount > 0);
            }

            //try to make a payment 
            if (!paymentHandler.MakePayment(base.Customer.Name,dAmount))
                return false;

            //make the cart into an order
            OrderModel orderModel = new OrderModel();
            string sID = orderModel.Add(base.Customer.Name, base.Customer.Address, dAmount);

            if (sID == null)
                return false;

            OrderLinesModel orderLinesModel = new OrderLinesModel();
            foreach (Cart cart in carts)
            {
                if (!orderLinesModel.Add(sID, cart.ProductCode, cart.Quantity, cart.UnitPrice))
                {
                    orderModel.Delete(sID);
                    orderLinesModel.Delete(sID);
                    return false;
                }
            }

            //clear the cart for this customer
            cartModel.Delete(base.Customer.Name);

            // get the order and the order items
            Order order = orderModel.Get(sID);
            IEnumerable<OrderLine> orderLines = orderLinesModel.GetAll(sID);

            // send email confirmation to the customer 
            EmailHandler emailhandler = new EmailHandler();
            emailhandler.SendOrderConfirmation(base.Customer, order, orderLines);

            // Notify the Courier
            courierHandler.Deliver(order, orderLines);

            return true;

        }

    }
}
