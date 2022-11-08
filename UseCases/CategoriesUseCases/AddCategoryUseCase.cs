using System;
using System.Collections.Generic;
using CoreBusiness;
using UseCases.DataStorePluginIntefaces;

namespace UseCases
{
    public class AddCategoryUseCase : IAddCategoryUseCase
    {
        private readonly ICategoryRepository categoryRepository;
        public AddCategoryUseCase(ICategoryRepository _categoryRepository)
        {
            categoryRepository = _categoryRepository;
        }
        public void Execute(Category category)
        {
            categoryRepository.AddCategory(category);
        }
    }
}
