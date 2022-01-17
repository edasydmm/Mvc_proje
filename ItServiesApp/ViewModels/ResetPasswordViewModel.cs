using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ItServiesApp.ViewModels
{
    public class ResetPasswordViewModel
    {

        [Required(ErrorMessage = "Yeni şifre alanı gereklidir")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Şifreniz minimum 6 karakterli olmalıdır!")]
        [Display(Name = "Yeni Şifre")]
        [DataType(DataType.Password)]

        public string NewPassword { get; set; }
        [Required(ErrorMessage = "Şifre tekrar alanı gereklidir.")]
        [DataType(DataType.Password)]
        [Display(Name = "Şifre Tekrar")]
        [Compare(nameof(NewPassword), ErrorMessage = "Şifreler uyuşmuyor")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
        public string UserId { get; set; }


    }
}
