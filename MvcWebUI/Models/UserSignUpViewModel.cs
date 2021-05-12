using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MvcWebUI.Models
{
    public class UserSignUpViewModel
    {
        [Display(Name = "Kullanıcı Adı: ")]
        [Required(ErrorMessage = "Kullanıcı adı boş geçilemez")]
        public string Username { get; set; }
        [Display(Name = "Şifre: ")]
        [Required(ErrorMessage = "Şifre boş geçilemez.")]
        public string Password{ get; set; }
        [Display(Name = "Şifrenizi doğrulayın:  ")]
        [Compare("Password",ErrorMessage ="Şifreler eşleşmiyor.")]
        public string ConfirmPassword { get; set; }
        [Display(Name = "İsim: ")]
        [Required(ErrorMessage = "İsim alanı boş geçilemez.")]
        public string FirstName { get; set; }
        [Display(Name = "Soyisim: ")]
        [Required(ErrorMessage = "Soyisim alanı boş geçilemez")]
        public string LastName { get; set; }
        [DataType(DataType.EmailAddress,ErrorMessage ="Lütfen doğru formatta giriniz.")]
        [Display(Name = "Email: ")]
        [Required(ErrorMessage = "Email alanı boş geçilemez")]
        public string Email { get; set; }
    }
}

