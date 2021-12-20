using Ilk_Mvc_Projesi.Models;
using Ilk_Mvc_Projesi.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mvc_Proje.Controllers.Apis
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductApiController : ControllerBase
    {
        private readonly NorthwindContext _dbContext;

        public ProductApiController(NorthwindContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpPost]
        public IActionResult Add(ProductViewModel model)
        {
            var product = new Product()
            {
                CategoryId = model.CategoryId,
                ProductName = model.ProductName,
                UnitPrice = model.UnitPrice
            };
            try
            {
                _dbContext.Products.Add(product);
                _dbContext.SaveChanges();
                return Ok(new
                {
                    Message = "Ürün ekleme işlemi başarılı",
                    Model = product
                });
            }
            catch(Exception ex)
            {
                return BadRequest($"Bir hata oluştu: {ex.Message}");
                
            }
      }
      
    }
}
