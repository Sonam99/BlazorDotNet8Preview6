using BlazorDotNet8Preview6.Models;
using Cypher.SeedWorks;

namespace BlazorDotNet8Preview6.Flows.ProductDetails.Events
{
    public class ProductUpdatedEvent : Event
    {
        public ProductModel Product { get; }

        public ProductUpdatedEvent(ProductModel product)
        {
            Product = product;
        }
    }
}
