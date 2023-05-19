using API_learn.Data;
using API_learn.Models;

namespace API_learn.Services
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _dbContext;
        public CategoryRepository(AppDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public CategoriesVM AddNewCategory(CategoriesVM category)
        {
            var ExistCategory = _dbContext.Categories.SingleOrDefault(x => x.CategoryName == category.CategoryName);
            if (ExistCategory == null)
            {
                var NewCategory = new Categories { CategoryName = category.CategoryName };
                _dbContext.Add(NewCategory);
                _dbContext.SaveChanges();
                return new CategoriesVM { CategoryID = NewCategory.CategoryID, CategoryName = NewCategory.CategoryName };
            }
            else
            {
                return null;
            }
        }

        public void DeleteCategory(int id)
        {
            var category = _dbContext.Categories.SingleOrDefault(x => x.CategoryID == id);
            if (category == null)
            {
                return;
            }
            else
            {
                _dbContext.Categories.Remove(category);
                _dbContext.SaveChanges();
            }
        }

        public List<CategoriesVM> GetCategories()
        {
            var categories = _dbContext.Categories.Select(x => new CategoriesVM
            {
                CategoryID = x.CategoryID,
                CategoryName = x.CategoryName
            });
            return categories.ToList();
        }

        public CategoriesVM GetCategoryById(int id)
        {
            var category = _dbContext.Categories.SingleOrDefault(x => x.CategoryID == id);
            if (category == null)
            {
                return null;
            }
            else
            {
                return new CategoriesVM
                {
                    CategoryID = id,
                    CategoryName = category.CategoryName
                };
            }
        }

        public void UpdateCategory(CategoriesVM category)
        {
            var _category = _dbContext.Categories.SingleOrDefault(x => x.CategoryID == category.CategoryID);
            _category.CategoryName = category.CategoryName;
            _dbContext.SaveChanges(); 
        }
    }
}
