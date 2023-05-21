using API_learn.Helper;
using API_learn.Models;

namespace API_learn.Services
{
    public interface IProductRepository
    {
        public List<ProductModel> Get(int page);
        public List<ProductModel> GetByName(string name, FilterHelper _fh, int page);
        public void Add(ProductModel pm);
        public void Update(string id, ProductModel pm);
        public void Delete(string id);
    }
}
