using API_learn.Data;
using API_learn.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_learn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly AppDbContext _dbContext;
        public CategoriesController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var listCategory = _dbContext.Categories.ToList();
            return Ok(listCategory);
        }
        [HttpGet("{Id}")]
        public IActionResult GetById(int id)
        {
            var category = _dbContext.Categories.FirstOrDefault(x => x.CategoryID == id);
            if (category == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(new
                {
                    Success = true,
                    Data = category
                });
            }
        }
        [HttpPost]
        public IActionResult AddNewCategory(CategoriesModel _newCategory)
        {
            var ExistCategory = _dbContext.Categories.FirstOrDefault(x => x.CategoryName == _newCategory.CategoryName);
            if (ExistCategory == null)
            {
                var NewCategory = new Categories()
                {
                    CategoryName = _newCategory.CategoryName
                };
                _dbContext.Categories.Add(NewCategory);
                _dbContext.SaveChanges();
                return Ok(new
                {
                    Success = true,
                    Data = NewCategory
                });
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpPut("{Id}")]
        public IActionResult UpdateById(int id, CategoriesModel _newCategory)
        {
            var category = _dbContext.Categories.FirstOrDefault(x => x.CategoryID == id);
            if (category == null)
            {
                return NotFound();
            }
            else
            {
                category.CategoryName = _newCategory.CategoryName;
                _dbContext.Categories.Update(category);
                _dbContext.SaveChanges();
                return Ok(new { Success = true, Data = category });
            }
        }
        [HttpDelete("{Id}")]
        public IActionResult DeleteById(int id)
        {
            var category = _dbContext.Categories.FirstOrDefault(x => x.CategoryID == id);
            if (category == null)
            {
                return NotFound();
            }
            else
            {
                _dbContext.Categories.Remove(category);
                _dbContext.SaveChanges();
                return Ok();
            }
        }
    }
}
