using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Supplier
    {
        public int SupplierID { get; set; }
        public int UserID { get; set; }
        public int ProductID { get; set; }
        
        public string CompanyName { get; set; }
        public string ContactName { get; set; }

    }
}
