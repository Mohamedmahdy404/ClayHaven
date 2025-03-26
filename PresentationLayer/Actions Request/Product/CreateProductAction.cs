using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.FileProviders;

namespace PresentationLayer.Actions_Request
{
    public class CreateProductAction
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; } 
        public int Amount { get; set; } = default;
        public IFormFile? ProductPic { get; set; }


    }
}
