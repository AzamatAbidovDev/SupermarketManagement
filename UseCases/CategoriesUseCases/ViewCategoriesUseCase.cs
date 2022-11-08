using System;
using CoreBusiness;
using System.Collections.Generic;
using UseCases.DataStorePluginIntefaces;

namespace UseCases
{
    public class ViewCategoriesUseCase : IViewCategoriesUseCase
    {
        public IEnumerable<Category> Execute()
        {
            return categoryRepository.GetCategories();
        }
        private readonly ICategoryRepository categoryRepository;
        public ViewCategoriesUseCase(ICategoryRepository _categoryRepository)
        {
            categoryRepository = _categoryRepository;
        }
    }
}
