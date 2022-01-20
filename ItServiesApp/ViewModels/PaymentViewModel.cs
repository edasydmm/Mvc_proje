using ItServiesApp.Models.Payment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ItServiesApp.ViewModels
{
    public class PaymentViewModel
    {
        public CardModel CardModel { get; set; }
        public AdsressModel AddressModel { get; set; }
        public BasketModel BasketModel { get; set; }
        public decimal Amount { get; set; }
        public decimal PaidAmount { get; set; }
        public int Installment{ get; set; }

    }



}
