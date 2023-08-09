using Cypher.SeedWorks;

namespace BlazorDotNet8Preview6.Flows.ProductDetails.Events
{
    public class ProductDeletedEvent : Event
    {
        public int ProductId { get; }
        public ProductDeletedEvent(int productId)
        {
            ProductId = productId;
        }
    }
}
