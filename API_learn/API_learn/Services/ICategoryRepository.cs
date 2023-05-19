using API_learn.Data;
using API_learn.Models;

namespace API_learn.Services
{
    public interface ICategoryRepository
    {
        List<CategoriesVM> GetCategories();
        CategoriesVM GetCategoryById(int id);
        CategoriesVM AddNewCategory(CategoriesVM category);
        void UpdateCategory(CategoriesVM category);
        void DeleteCategory(int id);
    }
}
