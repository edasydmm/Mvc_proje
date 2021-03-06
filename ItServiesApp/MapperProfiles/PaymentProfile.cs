using AutoMapper;
using ItServiesApp.Models.Payment;
using Iyzipay.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ItServiesApp.MapperProfiles
{
    public class PaymentProfile : Profile
    {
        public PaymentProfile()
        {
            CreateMap<CardModel, PaymentCard>().ReverseMap();
            CreateMap<AdsressModel, Address>().ReverseMap();
            CreateMap<CustomerModel, Buyer>().ReverseMap();
            CreateMap<BasketModel, BasketItem>().ReverseMap();
            CreateMap<InstallmentPriceModel, InstallmentPrice>().ReverseMap();
            CreateMap<InstallModel, InstallmentDetail>().ReverseMap();
            CreateMap<PaymentResponseModel, Payment>().ReverseMap();
        }


    }
}
