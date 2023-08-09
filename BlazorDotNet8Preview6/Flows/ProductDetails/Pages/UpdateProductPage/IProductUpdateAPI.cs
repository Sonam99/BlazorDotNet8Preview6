using BlazorDotNet8Preview6.Models;
using Zero.SharedKernel.Types.Result;

namespace BlazorDotNet8Preview6.Flows.ProductDetails.Pages.UpdateProductPage
{
    public interface IProductUpdateAPI
    {
        Task<Result<ProductModel>> UpdateProduct(int id, ProductInputModel model);
    }
}
