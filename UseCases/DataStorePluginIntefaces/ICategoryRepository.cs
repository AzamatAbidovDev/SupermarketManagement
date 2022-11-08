using System;
using System.Collections.Generic;
using CoreBusiness;

namespace UseCases.DataStorePluginIntefaces
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetCategories();
        void AddCategory(Category category);
        void UpdateCategory(Category category);
        Category GetCategoryByID(int categoryId);
        void DeleteCategory(int categoryId);
    }
}
