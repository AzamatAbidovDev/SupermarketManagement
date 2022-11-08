using CoreBusiness;

namespace UseCases
{
    public interface IGetProductByIDUseCase
    {
        Product Execute(int productId);
    }
}