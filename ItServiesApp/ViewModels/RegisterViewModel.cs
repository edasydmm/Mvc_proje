using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ItServiesApp.ViewModels
{
    public class RegisterViewModel
    {
        public string UserName { get; set; }
        [Required(ErrorMessage = "İsim alanı gereklidir.")]
        [Display(Name ="Ad")]
        [StringLength(50)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Ad alanı gereklidir.")]
        [Display(Name = "Ad")]
        [StringLength(50)]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Soyad alanı gereklidir.")]
        [Display(Name = "Ad")]
        [StringLength(50)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Mail alanı gereklidir.")]
        [Display(Name = "Ad")]
        [StringLength(50)]
        public string Password { get; set; }


        public string ConfirmPassword { get; set; }




    }
}
