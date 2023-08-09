using BlazorDotNet8Preview6.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorDotNet8Preview6.controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpGet("~/api/products")]
        public IActionResult GetAllProducts()
        {
            return Ok(products);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var product = products.FirstOrDefault(m => m.Id == id);
            if (product == null) return NotFound();
            return Ok(product);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, ProductInputModel model)
        {
            if (ModelState.IsValid)
            {
                var product = products.FirstOrDefault(m => m.Id == id);
                product.Title = model.Title!;
                product.Description = model.Description;
                product.Price = model.Price!.Value;
                return Ok(product);
            }
            return ValidationProblem(ModelState);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return NoContent();
        }

        List<ProductModel> products = new()
            {
                new ProductModel()
                {
                    Id = 1,
                    Title = "iPhone 9",
                    Description = "An apple mobile which is nothing like apple",
                    Price = 549,
                    //DiscountPercentage = 12.96,
                    //Rating = 4.69,
                    //Stock = 94,
                    //Brand = "Apple",
                    //Category = "smartphones",
                    Thumbnail = "https://dummyjson.com/image/i/products/1/thumbnail.jpg",
                    Images = new List<string>()
                    {
                        "https://dummyjson.com/image/i/products/1/1.jpg",
                        "https://dummyjson.com/image/i/products/1/2.jpg",
                        "https://dummyjson.com/image/i/products/1/4.jpg",
                        "https://dummyjson.com/image/i/products/1/thumbnail.jpg"
                    }
                },
                new ProductModel()
                {
                    Id = 2,
                    Title = "iPhone X",
                    Description = "SIM-Free, Model A19211 6.5-inch Super Retina HD display with OLED technology A12 Bionic chip with ...",
                    Price = 899,
                    Thumbnail = "https://dummyjson.com/image/i/products/2/thumbnail.jpg",
                    Images = new List<String>()
                    {
                        "https://dummyjson.com/image/i/products/2/1.jpg",
                        "https://dummyjson.com/image/i/products/2/2.jpg",
                        "https://dummyjson.com/image/i/products/2/3.jpg",
                        "https://dummyjson.com/image/i/products/2/thumbnail.jpg"
                    }
                },
                new ProductModel()
                {
                    Id = 3,
                    Title = "Samsung Universe 9",
                    Description = "Samsung's new variant which goes beyond Galaxy to the Universe",
                    Price = 1249,
                    Thumbnail = "https://dummyjson.com/image/i/products/3/thumbnail.jpg",
                    Images = new List<string>()
                    {
                        "https://dummyjson.com/image/i/products/3/1.jpg"
                    }
                },
                new ProductModel()
                {
                    Id = 4,
                    Title = "OPPOF19",
                    Description = "OPPO F19 is officially announced on April 2021.",
                    Price = 280,
                    Thumbnail = "https://dummyjson.com/image/i/products/4/thumbnail.jpg",
                    Images = new List<string>()
                    {
                        "https://dummyjson.com/image/i/products/4/1.jpg",
                        "https://dummyjson.com/image/i/products/4/2.jpg",
                        "https://dummyjson.com/image/i/products/4/3.jpg",
                        "https://dummyjson.com/image/i/products/4/4.jpg",
                        "https://dummyjson.com/image/i/products/4/thumbnail.jpg"
                    }
                },

            };
    }
}
