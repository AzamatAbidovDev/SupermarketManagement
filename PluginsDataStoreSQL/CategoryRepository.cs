using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UseCases.DataStorePluginIntefaces;

namespace PluginsDataStoreSQL
{
    public class CategoryRepository: ICategoryRepository
    {
        private readonly MarketContext db;
        public CategoryRepository(MarketContext _db)
        {
            db = _db;
        }
        public void AddCategory(Category category)
        {
            db.Categories.Add(category);
            db.SaveChanges();
        }

        public void DeleteCategory(int categoryId)
        {
            var category = db.Categories.Find(categoryId);
            if (category == null) return;

            db.Categories.Remove(category);
            db.SaveChanges();
        }

        public IEnumerable<Category> GetCategories()
        {
            return db.Categories.ToList();
        }

        public Category GetCategoryByID(int categoryId)
        {
            return db.Categories.Find(categoryId);
        }

        public void UpdateCategory(Category category)
        {
            var categor = db.Categories.Find(category.CategoryID);
            categor.Name = category.Name;
            categor.Description = category.Description;
            db.SaveChanges();
        }
    }
}
