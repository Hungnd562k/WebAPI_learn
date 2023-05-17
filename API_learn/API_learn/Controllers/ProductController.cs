using API_learn.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_learn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public static List<Product> Products = new List<Product>();

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(Products);
        }
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            try
            {
                var product = Products.SingleOrDefault(x => x.ProdId == Guid.Parse(id));
                if (product == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(product);
                } 
            } catch (Exception ex)
            {
                return BadRequest();
            }
            
        }
        [HttpPost]
        public IActionResult PushNew(ProductVM productVM)
        {
            var product = new Product
            {
                ProdId = Guid.NewGuid(),
                ProdName = productVM.ProdName,
                Price = productVM.Price
            };
            Products.Add(product);
            return Ok(new
            {
                Success = true, Data = product
            });
        }
        [HttpPut("{id}")]
        public IActionResult Update(string id, Product prod)
        {
            try
            {
                var product = Products.SingleOrDefault(x => x.ProdId == Guid.Parse(id));
                if (product == null)
                {
                    return NotFound();
                }
                if (id != product.ProdId.ToString())
                {
                    return BadRequest();
                }
                //update
                product.ProdName = prod.ProdName;
                product.Price = prod.Price;
                return Ok(new
                {
                    Success = true,
                    Data = prod
                });
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }   
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteById(string id)
        {
            try
            {
                var product = Products.SingleOrDefault(x => x.ProdId == Guid.Parse(id));
                if (product == null)
                {
                    return NotFound();
                }
                Products.Remove(product);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
