using System;
using System.Collections.Generic;
using CoreBusiness;
using UseCases.DataStorePluginIntefaces;

namespace UseCases
{
    public class EditCategoryUseCase : IEditCategoryUseCase
    {
        private readonly ICategoryRepository categoryRepository;
        public EditCategoryUseCase(ICategoryRepository _categoryRepository)
        {
            categoryRepository = _categoryRepository;
        }
        public void Execute(Category category)
        {
            categoryRepository.UpdateCategory(category);
        }
    }
}
