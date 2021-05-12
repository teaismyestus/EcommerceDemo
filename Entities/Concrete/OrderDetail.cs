using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class OrderDetail
    {
        public int OrderDetailID { get; set; }
        public int ProductID { get; set; }
        public int OrderID { get; set;  }
        public int UserID { get; set; }
        public int SupplierID { get; set; }



        public string OrderNumber { get; set; }

        public decimal Price { get; set; }

        public int quantity { get; set; }

        public decimal Total { get; set;  }

        
    }
}
