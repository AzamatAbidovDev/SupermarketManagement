using System;
using CoreBusiness;
using System.Collections.Generic;
using UseCases.DataStorePluginIntefaces;

namespace UseCases
{
    public class DeleteCategoryUseCase : IDeleteCategoryUseCase
    {
        private readonly ICategoryRepository categoryRepository;
        public DeleteCategoryUseCase(ICategoryRepository _categoryRepository)
        {
            categoryRepository = _categoryRepository;
        }
        public void Delete(Category category)
        {
            categoryRepository.DeleteCategory(category);
        }
    }
}
