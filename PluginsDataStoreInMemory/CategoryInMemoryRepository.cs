using System;
using System.Linq;
using CoreBusiness;
using UseCases.DataStorePluginIntefaces;
using System.Collections.Generic;

namespace PluginsDataStoreInMemory
{
    public class CategoryInMemoryRepository : ICategoryRepository
    {
        public IEnumerable<Category> GetCategories()
        {
            return categories;
        }
        private List<Category> categories;
        public CategoryInMemoryRepository()
        {
            //Some default categories
            categories = new List<Category>
            {
                new Category {CategoryID = 1, Name = "Bakery", Description = "Brown bread, Black bread"},
                new Category {CategoryID = 2, Name = "Beverage", Description = "Beverage Beverage"},
                new Category {CategoryID = 3, Name = "Meat", Description = "Cow, chicken, sheep"}

            };
        }
        public void AddCategory(Category category)
        {
            if (categories.Any(x => x.Name.Equals(category.Name, StringComparison.OrdinalIgnoreCase))) return;

            if (categories != null && categories.Count > 0)
            {
                var maxID = categories.Max(x => x.CategoryID);
                category.CategoryID = maxID + 1;
            }
            else category.CategoryID = 1;

            categories.Add(category);
        }

        public void UpdateCategory(Category category)
        {
            var categoryToUpdate = GetCategoryByID(category.CategoryID);
            if (categoryToUpdate != null)
            {
                categoryToUpdate.Name = category.Name;
                categoryToUpdate.Description = category.Description;
            }
        }

        public Category GetCategoryByID(int categoryId)
        {
            return categories?.FirstOrDefault(x => x.CategoryID == categoryId);
        }
        public void DeleteCategory(int categoryId)
        {
            categories?.Remove(GetCategoryByID(categoryId));
        }
    }
}
