using CoreBusiness;

namespace UseCases
{
    public interface IGetCategoryByIDUseCase
    {
        Category Execute(int categoryId);
    }
}