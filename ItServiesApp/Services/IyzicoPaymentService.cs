using AutoMapper;
using ItServiesApp.Models.Payment;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ItServiesApp.Services
{
    public class IyzicoPaymentService : IPaymentService
    {
        private readonly IConfiguration _configuration;
        private readonly IysicoPaymentOptions _options;
        private readonly IMapper _mapper;


        public InstallmentPriceModel CheckInstallments(string binNumber, decimal price)
        {
            throw new NotImplementedException();
        }

        public PaymentResponseModel Pay(PaymentModel modell)
        {
            throw new NotImplementedException();
        }
    }
}
