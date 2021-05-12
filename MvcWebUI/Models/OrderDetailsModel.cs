using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcWebUI.Models
{
    public class OrderDetailsModel
    {
        public int ProductID { get; set; }
        public int userID { get; set; }

        public decimal TotalPrice { get; set; }
        public int Quantity { get; set; }

        public decimal Discount { get; set; }
        public int OrderID { get; set; }
    }
}
