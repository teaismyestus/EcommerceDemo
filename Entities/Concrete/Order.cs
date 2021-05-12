using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Order
    {
        public int OrderID { get; set; }
        public int OrderDetailID { get; set; }
        public int CustomerID { get; set; }

        public int ShipperID { get; set; }


    }
}
