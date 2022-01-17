using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ItServiesApp.Models.Payment
{
    public class PaymentResponseModel
    {

        public string Price { get; set; }
        public string PaldPrice { get; set; }
        public int? Installment { get; set; }
        public string Currency { get; set; }
        public string  PaymnetStatus { get; set; }

        public string CardType { get; set; }
        public string CardToken { get; set; }
        public string  BinNumber { get; set; }
        public string  LastFourDigts { get; set; }
        public string  BasketId { get; set; }


    }
}
