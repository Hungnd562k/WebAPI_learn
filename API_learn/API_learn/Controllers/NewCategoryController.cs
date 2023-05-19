using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API_learn.Services;
using API_learn.Models;
using API_learn.Data;

namespace API_learn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewCategoryController : ControllerBase
    {
        private readonly ICategoryRepository _repo;
        public NewCategoryController(ICategoryRepository repo)
        {
            _repo = repo;
        }
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_repo.GetCategories());
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_repo.GetCategoryById(id));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpPost] //bug is here
        public IActionResult Add(CategoriesVM c)
        {
            try
            {
                var NewCategory = _repo.AddNewCategory(c);
                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpPut]
        public IActionResult Update(CategoriesVM c)
        {
            try
            {
                _repo.UpdateCategory(c);
                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _repo.DeleteCategory(id);
                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
