using Zero.SharedKernel.Types.Result;

namespace BlazorDotNet8Preview6.Flows.ProductDetails
{
    public interface IProductDeleteAPI
    {
        Task<Result> DeleteProduct(int id);
    }
}
