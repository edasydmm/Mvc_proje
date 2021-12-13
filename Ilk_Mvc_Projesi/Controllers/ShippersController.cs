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
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var shipper = new Shipper()
            {
                //CategoryId = 1,//hata versin diye yazdık
                CompanyName = model.CompanyName,
                Phone = model.Phone
            };
            _context.Shippers.Add(shipper);

            try
            {
                _context.SaveChanges();
                return RedirectToAction("Detail", new { id = shipper.ShipperId });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"{model.CompanyName} eklenirken bir hata oluştu. Tekrar deneyiniz");
                return View(model);
            }
        }
        public IActionResult Update(int? id)
        {
            var shipper = _context.Shippers.FirstOrDefault(x => x.ShipperId == id);
            if (shipper == null) return RedirectToAction(nameof(Index));

            var model = new ShipperViewModel()
            {
                ShipperID = shipper.ShipperId,
                CompanyName = shipper.CompanyName,
                Phone = shipper.Phone

            };

            return View(model);
        }


        [HttpPost]
        public IActionResult Update(ShipperViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var shipper = _context.Shippers.FirstOrDefault(x => x.ShipperId== model.ShipperID);

            try
            {
                shipper.CompanyName = model.CompanyName;
                shipper.Phone = model.Phone;
               
                _context.Shippers.Update(shipper);

                _context.SaveChanges();
                return RedirectToAction("Detail", new { id = shipper.ShipperId });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"{model.CompanyName} güncellenirken bir hata oluştu. Tekrar deneyiniz");
                return View(model);
            }
        }
    }
}




