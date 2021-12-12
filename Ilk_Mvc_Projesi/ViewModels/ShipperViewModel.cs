using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Ilk_Mvc_Projesi.ViewModels
{
    public class ShipperViewModel
    {
        [Display(Name = "Şirket Adı")]
        public string CompanyName { get; set; }

        [Display(Name = "Numara")]
        public string  Phone  { get; set; }

        public int ShipperID{ get; set; }
    }
}
