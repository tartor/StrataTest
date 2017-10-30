# StrataTest


The class library contains several classes :  
  
**Config** - the data have to come externally from places like web.config .  
  
**Repository** - simulates DataSource. Instead of database it conatains lists which we manipulate with LINQ.  
  
**Model Classes**  
  
All the low level data manipulation is done in the ....Model classes.  
If we decide to change the DataSource only these classes have to be changed.  
We can implement a base model class that implements database or xml interaction depending on the DataSource.  
All the logic in the other classes stays the same.  
  
**Handler Classes**  
  
More specialised classes that handle specific routine tasks.  
Payment, Courier , Email, HttpRequests  etc.  
There may be several Payment handlers ( PayPal, WorldsPay ...  ) and Courier handlers classes ( Royal Mail, Dx ....  ) .  
We instantiate the one needed for the specific transaction based on web.config defined strings or Provider web definitions and pass them when needed.  
  
**Action Classes**  
  
All the application logic manipulation is done in the ....Action classes .  
Most of the Action classes inherit from AuthenticatedAction to ensure they are used only when there is a logged in user .  
  
External library **RazorEngine** is used utilise email template. The email template for this example is kept in memory but can be held in a file and read on demamnd.  
  
The parameters for the **SmtpClient** used to send the email should be available in the web.config .  
  
