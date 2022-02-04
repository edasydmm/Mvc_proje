using AutoMapper;
using ItServiesApp.Data;
using ItServiesApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ItServiesApp.Controllers
{
    public class HomeController : Controller
    {

        private readonly MyContext _dbContext;
        private readonly IMapper _mapper;

        public HomeController(MyContext dbContext , IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;

        }

        public IActionResult Index()
        {
            //var model = _dbContext.SubscriptionTypes
            //    .OrderBy(x => x.Price).ToList()
            //    .Select(x => _mapper.Map<SubscriptionTypeViewModel>(x))
            //    .ToList();


            return View();
        }
    }
}
