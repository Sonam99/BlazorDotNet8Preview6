namespace BlazorDotNet8Preview6.Models
{
    public class ProductModel
    {

        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public int Price { get; set; }
        public string Thumbnail { get; set; }
        public IList<string> Images { get; set; }
    }
}
