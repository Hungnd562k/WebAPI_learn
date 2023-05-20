using API_learn.Controllers;
using API_learn.Data;
using API_learn.Models;

namespace API_learn.Services
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _dbContext;
        public ProductRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        void IProductRepository.Add(ProductModel pm)
        {
            _dbContext.Products.Add(new Product
            {
                ProductId = Guid.NewGuid(),
                ProdName = pm.ProdName,
                Description = pm.Description,
                Price = pm.Price,
                Sale = pm.Sale,
                CategoryId = pm.CategoryId,
            });
            _dbContext.SaveChanges();
        }

        void IProductRepository.Delete(string id)
        {
            var product = _dbContext.Products.FirstOrDefault(x => x.ProductId == Guid.Parse(id));
            if (product != null)
            {
                _dbContext.Products.Remove(product);
                _dbContext.SaveChanges();
            }
        }

        List<ProductModel> IProductRepository.Get()
        {
            var _products = _dbContext.Products.Select(x => new ProductModel
            {
                ProdName = x.ProdName,
                Price = x.Price,
                Description = x.Description,
                Sale = x.Sale
            });
            return _products.ToList();
        }

        ProductModel IProductRepository.GetById(string id)
        {
            var _product = _dbContext.Products.SingleOrDefault(x => x.ProductId == Guid.Parse(id));
            if (_product == null)
            {
                return null;
            }
            else
            {
                return new ProductModel
                {
                    ProdName = _product.ProdName,
                    Price = _product.Price,
                    Description = _product.Description,
                    Sale = _product.Sale
                };
            }
        }

        void IProductRepository.Update(string id, ProductModel pm)
        {
            var product = _dbContext.Products.FirstOrDefault(x => x.ProductId == Guid.Parse(id));
            if (product != null)
            {
                product.ProdName = pm.ProdName;
                product.Description = pm.Description;
                product.Price = pm.Price;
                product.Sale = pm.Sale;
                product.CategoryId = pm.CategoryId;
                _dbContext.SaveChanges();
            }
        }
    }
}
