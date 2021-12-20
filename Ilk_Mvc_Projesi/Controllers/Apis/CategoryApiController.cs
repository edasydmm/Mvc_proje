using Ilk_Mvc_Projesi.Models;
using Ilk_Mvc_Projesi.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mvc_Proje.Controllers.Apis
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoryApiController : ControllerBase
    {
        private readonly NorthwindContext _dbcontext;

        public CategoryApiController(NorthwindContext dbContext)
        {
            _dbcontext = dbContext;
        }

        [HttpGet]
        public IActionResult GetCategories()
        {
            try
            {
                var categories = _dbcontext.Categories
                      .Include(x => x.Products)
                      .OrderBy(x => x.CategoryName)
                      .Select(x => new CategoryViewModel()
                      {

                          CategoryId = x.CategoryId,
                          CategoryName = x.CategoryName,
                          Description = x.Description,
                          ProductCount = x.Products.Count
                      })
                .ToList();


                return Ok(categories);


            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        [HttpPost]
        public IActionResult AddCategory(CategoryViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var category = new Category()
            {
                CategoryName = model.CategoryName,
                Description = model.Description
            };
            _dbcontext.Categories.Add(category);

            try
            {
                _dbcontext.SaveChanges();
                return Ok(new
                {
                    Message = "Kategori ekleme işlemi başarılı",
                    Model = category
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        [Route("~/api/categoryapi/updatecategory/{id?}")] //custom route
        public IActionResult UpdateCategory(int? id, CategoryViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();

            }

            var category = _dbcontext.Categories.FirstOrDefault(x => x.CategoryId == id);
            if (category == null)
            {
                return NotFound("Kategori bulunamadı");
            }
            category.CategoryName = model.CategoryName;
            category.Description = model.Description;


            try
            {

                _dbcontext.Categories.Update(category);
                _dbcontext.SaveChanges();
                return Ok(new
                {
                    Message = "Kategori güncelleme başarılı",
                    Model = category
                });

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }

        public IActionResult DeleteCategory(int? id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();

            }
            var category = _dbcontext.Categories.FirstOrDefault(x => x.CategoryId == id);
            if (category == null)
            {
                return NotFound("Kategori bulunamadı");
            }

            try
            {

                _dbcontext.Categories.Remove(category);
                _dbcontext.SaveChanges();
                return Ok(new
                {
                    Message = "Kategori silme başarılı",
                    Model = category
                });

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }

        }

    }
}

    

    

