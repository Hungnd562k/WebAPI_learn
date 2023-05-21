using API_learn.Controllers;
using API_learn.Data;
using API_learn.Helper;
using API_learn.Models;

namespace API_learn.Services
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _dbContext;
        private static int PAGE_SIZE { get; set; } = 5;
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

        List<ProductModel> IProductRepository.Get(int page = 1)
        {
            var _products = _dbContext.Products.Select(x => new ProductModel
            {
                ProdName = x.ProdName,
                Price = x.Price,
                Description = x.Description,
                Sale = x.Sale
            }).Skip((page - 1) * PAGE_SIZE).Take(PAGE_SIZE);
            return _products.ToList();
        }

        List<ProductModel> IProductRepository.GetByName(string name, FilterHelper _fh, int page = 1)
        {
            var matchProduct = _dbContext.Products.Where(x => x.ProdName.ToLower().Contains(name) && x.Price > _fh.from && x.Price < _fh.to);
            IQueryable<ProductModel> pm = matchProduct.Select(x => new ProductModel
            {
                ProdName = x.ProdName,
                Price = x.Price,
                Description = x.Description,
                Sale = x.Sale
            }).Skip((page - 1) * PAGE_SIZE).Take(PAGE_SIZE); 
            List<ProductModel> result = null;
            switch (_fh.SortBy)
            {
                case "asc":
                    result = pm.OrderBy(x => x.Price).ToList();
                    break;
                case "desc":
                    result = pm.OrderByDescending(x => x.Price).ToList();
                    break;
            }
            return result;
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
