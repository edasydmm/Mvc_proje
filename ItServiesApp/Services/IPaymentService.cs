using ItServiesApp.Models.Payment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ItServiesApp.Services
{
   public interface IPaymentService
    {
        public InstallModel CheckInstallments(string binNumber, decimal price);
        public PaymentResponseModel Pay(PaymentModel modell);



       
    }
}
