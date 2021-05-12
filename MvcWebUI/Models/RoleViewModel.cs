using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MvcWebUI.Models
{
    public class RoleViewModel
    {
        [Required(ErrorMessage ="Rol Adı boş geçilemez.")]
        [Display(Name="Ad")]
        public string Name { get; set; }
    }
}
