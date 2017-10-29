using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using RazorEngine;
using RazorEngine.Templating;
using RazorEngine.Configuration;
using RazorEngine.Compilation;

namespace StrataTest
{
    class EmailHandler
    {
        public bool SendOrderConfirmation(Customer customer,Order order, IEnumerable<OrderLine> orderLines )
        {

            var model = new { Order = order, Lines = orderLines };  

            // template can be read from a file
            string template =
@"<html>
<body>
Hi @Model.Order.Customer,<br/>
<br/>
Here is your order ID @Model.Order.Id <br/>
<br/>
@foreach(var line in Model.Lines) {
    Product : @line.ProductCode Quantity : @line.Quantity Price : @line.UnitPrice <br/>
}
</body>
</html>";

            MailMessage mailMessage = new MailMessage();
            mailMessage.Subject = "Order Confirmation";

            mailMessage.Body = Razor.Parse(template, model);

            mailMessage.From = (new MailAddress(Repository.Config.SenderEmail));
            mailMessage.To.Add(new MailAddress(customer.Email));
            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Send(mailMessage);
            return true;
        }
    }
}
