using AutoMapper;
using ItServiesApp.Models.Identity;
using ItServiesApp.Models.Payment;
using Iyzipay.Model;
using Iyzipay.Request;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using MUsefullMethods;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace ItServiesApp.Services
{
    public class IyzicoPaymentService : IPaymentService
    {
        private readonly IConfiguration _configuration;
        private readonly IysicoPaymentOptions _options;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        public IyzicoPaymentService(IConfiguration configuration, IMapper mapper, UserManager<ApplicationUser> userManager)
        {
            _configuration = configuration;
            _mapper = mapper;
            _userManager = userManager;
            var section = _configuration.GetSection(IysicoPaymentOptions.Key);
            _options = new IysicoPaymentOptions()
            {
                ApiKey = section["ApiKey"],
                SecretKey = section["SecretKey"],
                BaseUrl = section["BaseUrl"],
                ThreedsCallbackUrl = section["ThreedsCallbackUrl"],
            };

        }


        private string GenerateUniqueCode()
        {
            return StringHelpers.GenerateUniqueCode();
        }

        private CreatePaymentRequest InitialPaymentRequest(PaymentModel model)
        {
            var paymentRequest = new CreatePaymentRequest
            {
                Installment = model.Insatllment,
                Locale = Locale.TR.ToString(),
                ConversationId = GenerateUniqueCode(),
                Price = model.Price.ToString(new CultureInfo("en-US")),
                PaidPrice = model.PaidPrice.ToString(new CultureInfo("en-US")),
                Currency = Currency.TRY.ToString(),
                BasketId = StringHelpers.GenerateUniqueCode(),
                PaymentChannel = PaymentChannel.WEB.ToString(),
                PaymentGroup = PaymentGroup.SUBSCRIPTION.ToString(),
                PaymentCard = _mapper.Map<PaymentCard>(model.CardModel)

            };

            var user = _userManager.FindByIdAsync(model.UserId).Result;
            var buyer = new Buyer
            {
                Id = user.Id,
                Name = user.Name,
                Surname = user.Surname,
                GsmNumber = user.PhoneNumber,
                Email = user.Email,
                IdentityNumber = "11111111110",
                LastLoginDate = $"{DateTime.Now:yyy-MM-dd HH:mm:ss}",
                RegistrationDate = $"{user.CreatedDate:yyy-MM-dd HH:mm:ss}",
                RegistrationAddress = "Channuma Mah. Balbaros Bulvarı No:9 Beşiktaş",
                Ip = model.Ip,
                City = "İstanbul",
                Country = "Turkey",
                ZipCode = "34732"
            };

            paymentRequest.Buyer = buyer;

            var billingAddress = new Address
            {
                ContactName = $"{user.Name} {user.Surname}",
                City = "Istanbul",
                Country = "Turkey",
                Description = "Cihannuma Mah. Barbaros Bulvarı No:9 Beşiktaş",
                ZipCode = "34742"
            };
            paymentRequest.BillingAddress = billingAddress;

            var basketItems = new List<BasketItem>();
            var firsBasketItem = new BasketItem
            {




                Id = "BT101",
                Name = "Binocular",
                Category1 = "Collectibles",
                Category2 = "Accessories",
                ItemType = BasketItemType.VIRTUAL.ToString(),
                Price = model.Price.ToString(new CultureInfo("en-US"))
            };
            basketItems.Add(firsBasketItem);
            paymentRequest.BasketItems = basketItems;
            return paymentRequest;
        }



        public InstallModel CheckInstallments(string binNumber, decimal price)
        {
            if (binNumber.Length > 6)
                binNumber = binNumber.Substring(0, 6);



            var conversationId = GenerateUniqueCode();
            var request = new RetrieveInstallmentInfoRequest
            {
                Locale = Locale.TR.ToString(),
                ConversationId = conversationId,
                BinNumber = binNumber,
                Price = price.ToString(new CultureInfo("en-US")),
            };

            var result = InstallmentInfo.Retrieve(request, _options);
            if (result.Status == "failure")
            {
                throw new Exception(result.ErrorMessage);
            }

            if (result.ConversationId != conversationId)
            {
                throw new Exception("Hatalı istek oluturuldu");
            }

            var resultModel = _mapper.Map<InstallModel>(result.InstallmentDetails[0]);

            return resultModel;
        }

        public PaymentResponseModel Pay(PaymentModel model)
        {
            var request = InitialPaymentRequest(model);
            var payment = Payment.Create(request, _options);
            return _mapper.Map<PaymentResponseModel>(payment);


        }


    }
}

