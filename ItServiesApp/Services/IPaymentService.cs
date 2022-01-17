using ItServiesApp.Models.Payment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ItServiesApp.Services
{
   public interface IPaymentService
    {
        public InstallmentPriceModel CheckInstallments(string binNumber, decimal price);
        public void Pay();



       
    }
}
