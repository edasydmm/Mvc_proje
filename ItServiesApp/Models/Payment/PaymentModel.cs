using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ItServiesApp.Models.Payment
{
    public class PaymentModel
    {
        public string PaymentId { get; set; }
        public decimal Price { get; set; }
        public decimal PaidPrice { get; set; }
        public int Insatllment { get; set; }
        public CardModel CardModel { get; set; }
        public List<BasketModel> BasketModel { get; set; }
        public CustomerModel Customer { get; set; }
        public AdsressModel Address { get; set; }
        public string Ip { get; set; }
        public string UserId { get; set; }






    }
}
