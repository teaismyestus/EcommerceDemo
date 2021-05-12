
using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Entities.Concrete
{
   public class Product:IEntity
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
    }
}
