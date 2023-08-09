using BlazorDotNet8Preview6.Models;
using Zero.SharedKernel.Types.Result;

namespace BlazorDotNet8Preview6.States
{
    public interface IProductAPI
    {
        public Task<Result<List<ProductModel>>> FetchAllProducts();

        public Task<Result<ProductModel>> GetProduct(int id);
    }
}
