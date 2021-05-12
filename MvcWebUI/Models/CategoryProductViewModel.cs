using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace MvcWebUI.Models
{
    public class CategoryProductViewModel
    {
        [DisplayName("Ürün ID")]
        public int ProductID { get; set; }
        [DisplayName("Kategori ID")]
        public int CategoryID { get; set; }
        [DisplayName("Satıcı ID")]
        public int SupplierID { get; set; }
        [DisplayName("Ürün Adı")]

        public string ProductName { get; set; }

        [DisplayName("Birim Başına Ağırlık")]
        public string QuantityPerUnit { get; set; }
        [DisplayName("Stok Adedi")]
        public short UnitsInStock { get; set; }
        [DisplayName("Birim Fiyatı")]
        public decimal UnitPrice { get; set; }
        public string PictureUrl { get; set; }
        public string Description { get; set; }
        public IFormFile Picture { get; set; }
        public ICollection<Category> Categories { get; set; }
    }
}
