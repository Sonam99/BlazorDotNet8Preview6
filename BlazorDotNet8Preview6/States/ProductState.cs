using BlazorDotNet8Preview6.Flows.ProductDetails.Events;
using BlazorDotNet8Preview6.Models;
using Cypher.SeedWorks;
using Zero.SharedKernel.Types.Result;

namespace BlazorDotNet8Preview6.States
{
    public class ProductState : StateContainer
    {
        public readonly IProductAPI _productApi;

        private List<ProductModel> _products = new();
        public IReadOnlyList<ProductModel> AllProducts => _products.AsReadOnly();

        bool _productLoaded = false;

        public ProductState(IProductAPI productApi, EventBus eventBus) : base(eventBus)
        {
            _productApi = productApi;

            RegisterListener<ProductUpdatedEvent>((e) =>
            {
                var index = _products.FindIndex(m => m.Id == e.Product.Id);
                if (index > -1)
                {
                    _products[index] = e.Product;
                    NotifyStateChanged();
                }
            });

            RegisterListener<ProductDeletedEvent>((e) =>
            {
                var removedCount = _products.RemoveAll(m => m.Id == e.ProductId);

                if (removedCount > 0)
                {
                    NotifyStateChanged();
                }

            });
        }

        public async Task<Result<ProductModel>> GetProduct(int id)
        {
            var product = _products.FirstOrDefault(m => m.Id == id);

            if (product != null) return Result.Success(product);

            return await _productApi.GetProduct(id);
        }

        public async Task<Result> LoadAllProducts()
        {

            if (_productLoaded) return Result.Success();

            var result = await _productApi.FetchAllProducts();

            if (result.IsSuccess)
            {
                _products = result.Value;
                _productLoaded = true;
            }
            return result;
        }
    }
}
