using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MvcWebUI.Models
{
    public class SupplierInfoModel
    {
        
        public int SupplierID { get; set; }
        
        [Display(Name ="Firma Adını Giriniz.")]
        public string CompanyName { get; set; }

        [Display(Name ="Email adresinizi giriniz:")]
        public string ContactName { get; set; }
        [Display(Name ="Varsa ek iletişim bilgilerini giriniz.")]
        public string ContactTitle { get; set; }
        [Display(Name ="Adres bilgilerini giriniz.")]
        public string Adress { get; set; }
        public string City { get; set; }
        [Display(Name =("Telefon numarasını giriniz."))]
        public string Phone { get; set; }
        [Display(Name ="Vergi Numarasını giriniz.")]
        public string TaxNumber { get; set; }
        [Display(Name ="Vergi dairesi bilgilerini giriniz.")]
        public string TaxOffice { get; set; }
        [Display(Name ="Firmanızın logosu:")]
        public string LogoUrl { get; set; }
        public IFormFile Picture { get; set; }
    }
}
