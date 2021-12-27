using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ItServiesApp.ViewModels
{
    public class PasswordChangeViewModel
    {[Required(ErrorMessage ="Eski şifre alanı gereklidir")]
    [StringLength(100,MinimumLength =6,ErrorMessage ="Şifreniz minimum 6 karakterli olmalıdır!")]
    [Display(Name ="Eski Şifre")]
    [DataType(DataType.Password)]

    public string OldPassword { get; set; }
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




    }
}
