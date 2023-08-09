using BlazorDotNet8Preview6.Flows.ProductDetails;
using BlazorDotNet8Preview6.Flows.ProductDetails.Pages.UpdateProductPage;
using BlazorDotNet8Preview6.Models;
using BlazorDotNet8Preview6.States;
using Cypher.SeedWorks;
using Zero.SharedKernel.Types.Result;

namespace BlazorDotNet8Preview6.Services.APIs
{
    public class ProductAPI : IProductAPI, IProductDeleteAPI, IProductUpdateAPI
    {
        private readonly APIHelper _apiHelper;

        public ProductAPI(APIHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }

        public async Task<Result<List<ProductModel>>> FetchAllProducts()
        {
            return await _apiHelper.GetAsync<List<ProductModel>>("/api/products");
        }

        public async Task<Result<ProductModel>> GetProduct(int id)
        {
            return await _apiHelper.GetAsync<ProductModel>("/api/product/" + id);
        }

        public async Task<Result<ProductModel>> UpdateProduct(int id, ProductInputModel model)
        {
            return await _apiHelper.PutAsync<ProductModel, ProductInputModel>("/api/product/" + id, model);
        }

        public async Task<Result> DeleteProduct(int id)
        {
            return await _apiHelper.DeleteAsync("/api/product/" + id);
        }
    }
}
