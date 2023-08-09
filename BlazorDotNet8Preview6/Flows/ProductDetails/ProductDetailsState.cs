using BlazorDotNet8Preview6.Flows.ProductDetails.Events;
using BlazorDotNet8Preview6.Models;
using Cypher.SeedWorks;
using Zero.SharedKernel.Types.Result;

namespace BlazorDotNet8Preview6.Flows.ProductDetails
{
    public class ProductDetailsState : StateContainer
    {
        private readonly IProductDeleteAPI _productDeleteAPI;
        public ProductModel Product { get; private set; }

        public ProductDetailsState(ProductModel product, EventBus eventBus, IProductDeleteAPI productDeleteAPI) : base(eventBus)
        {
            Product = product;

            RegisterListener<ProductUpdatedEvent>((e) =>
            {
                Product.Title = e.Product.Title;
                Product.Price = e.Product.Price;
                Product.Description = e.Product.Description;
            });
            _productDeleteAPI = productDeleteAPI;
        }

        public async Task<Result> Delete()
        {
            var result = await _productDeleteAPI.DeleteProduct(Product.Id);
            if (result.IsSuccess)
            {
                TriggerEvent(new ProductDeletedEvent(Product.Id));
            }
            return result;
        }
    }
}
