using Castle.MicroKernel.SubSystems.Conversion;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MvcWebUI.Models
{
    public class UserUpdateViewModel
    {
        [Display(Name ="Email: ")]
        [Required(ErrorMessage ="Email alanı boş geçilemez.")]
        [EmailAddress(ErrorMessage ="Geçerli bir email adresi giriniz.")]
        public string Email { get; set; }
        [Display(Name = "Telefon Numarası: ")]
        public string PhoneNumber { get; set; }
        [Display(Name = "İsim: ")]
        public string FirstName { get; set; }
        [Display(Name = "Resim: ")]
        public IFormFile  Picture { get; set; }

        [Display(Name = "Soyisim: ")]
        public string LastName { get; set; }
        public string PictureUrl { get; set; }

    }
}
