using API_learn.Models;

namespace API_learn.Services
{
    public interface IProductRepository
    {
        public List<ProductModel> Get();
        public ProductModel GetById(string id);
        public void Add(ProductModel pm);
        public void Update(string id, ProductModel pm);
        public void Delete(string id);
    }
}
