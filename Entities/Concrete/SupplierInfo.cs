using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
   public class SupplierInfo
    {
        public int SupplierInfoID { get; set; }
        public string CompanyName { get; set; }

        public string ContactName { get; set; }

        public string ContactTitle { get; set; }

        public string Adress { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
        public string TaxNumber { get; set; }
        public string TaxOffice { get; set; }
        public string LogoUrl { get; set; }
    }
}
