using System;
using System.Collections.Generic;
using CoreBusiness;
using UseCases.DataStorePluginIntefaces;

namespace UseCases
{
    public class GetCategoryByIDUseCase : IGetCategoryByIDUseCase
    {
        private readonly ICategoryRepository categoryRepository;
        public GetCategoryByIDUseCase(ICategoryRepository _categoryRepository)
        {
            categoryRepository = _categoryRepository;
        }
        public Category Execute(int categoryId)
        {
            return categoryRepository.GetCategoryByID(categoryId);
        }
    }
}
