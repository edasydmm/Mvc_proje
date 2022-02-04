using AutoMapper;
using ItServiesApp.Models.Entities;
using ItServiesApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ItServiesApp.MapperProfiles
{
    public class EntityProfile :Profile
    {

        public EntityProfile()
        {
            CreateMap<SubscriptionType,SubscriptionTypeViewModel>().ReverseMap();



        }
    }
}
