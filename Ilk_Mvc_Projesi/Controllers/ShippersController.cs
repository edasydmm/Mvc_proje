using System;
using System.Linq;
using Ilk_Mvc_Projesi.Models;
using Ilk_Mvc_Projesi.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Ilk_Mvc_Projesi.Controllers
{
    public class ShipperController : Controller
    {
        private readonly NorthwindContext _context;

        public ShipperController(NorthwindContext context)
        {
            _context = context;
        }

        //[HttpGet]
        public IActionResult Index()
        {
            var data = _context.Shippers
               .Include(x => x.Orders)
               .OrderBy(x => x.ShipperId)
                .ToList();

            return View(data);
        }
        public IActionResult Detail(int? ıd)
        {

            var Shipper = _context.Shippers
                .Include(x => x.Orders)
                .FirstOrDefault(x => x.ShipperId == ıd);
            if (Shipper == null)
                return RedirectToAction(nameof(Index));
            return View(Shipper);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ShipperViewModel model)
        {
           
                return View();
            }
        }



    }

