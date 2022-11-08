using CoreBusiness;
using System.Collections.Generic;

namespace UseCases
{
    public interface IViewProductsByCategoryID
    {
        IEnumerable<Product> Execute(int categoryId);
    }
}