using BlazorDotNet8Preview6.Flows.ProductDetails.Events;
using BlazorDotNet8Preview6.Models;
using Cypher.SeedWorks;
using Zero.SharedKernel.Types.Result;

namespace BlazorDotNet8Preview6.Flows.ProductDetails.Pages.UpdateProductPage
{
    public class UpdateProductState : StateContainer
    {
        private readonly ProductModel _product;
        private readonly IProductUpdateAPI _api;
        public UpdateProductState(ProductModel product, EventBus eventBus, IProductUpdateAPI api) : base(eventBus)
        {
            _product = product;
            Title = Result.Success(product.Title);
            Description = Result.Success(product.Description);
            Price = Result.Success(product.Price);
            _api = api;
        }

        public Result<string> Title { get; private set; }
        public void UpdateTitle(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                Title = Result.Failure<string>("Title can't be blank.");
            }
            else if (value.Length > 30)
            {
                Title = Result.Failure<string>("Title is too long.");
            }
            else
            {
                Title = Result.Success(value);
            }
            NotifyStateChanged();
        }

        public Result<string?> Description { get; private set; }
        public void UpdateDescription(string? value)
        {
            Description = Result.Success(value);
            NotifyStateChanged();
        }

        public Result<int> Price { get; private set; }
        public void UpdatePrice(string value)
        {
            if (!string.IsNullOrEmpty(value) && int.TryParse(value, out int price))
            {
                if (price <= 0)
                {
                    Price = Result.Failure<int>("Price should be more than zero.");
                }
                else
                {
                    Price = Result.Success(price);
                }
            }
            else
            {
                Price = Result.Failure<int>("Price is invalid.");
            }
            NotifyStateChanged();
        }

        public bool IsValid => Title.IsSuccess && Price.IsSuccess;

        public async Task<Result> Update()
        {
            var model = new ProductInputModel
            {
                Title = Title.Value,
                Price = Price.Value,
                Description = Description.Value
            };
            var result = await _api.UpdateProduct(_product.Id, model);

            if (result.IsSuccess)


            {
                TriggerEvent(new ProductUpdatedEvent(result.Value));
            }
            return result;
        }
    }
}
