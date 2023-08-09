using System.ComponentModel.DataAnnotations;

namespace BlazorDotNet8Preview6.Models
{
    public class ProductInputModel
    {
        [Required(ErrorMessage = "Title is required.")]
        public string? Title { get; set; }

        [Required(ErrorMessage = "Price is required.")]
        public int? Price { get; set; }

        public string? Description { get; set; }
    }
}
