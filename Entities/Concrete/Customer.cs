using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
   public class Customer
    {
        public int CustomerID { get; set; }
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
        public string Email { get; set; }
        
        public string City { get; set; }
        
        public string Address { get; set; }

        public string BillingAdress { get; set; }

    }
}
