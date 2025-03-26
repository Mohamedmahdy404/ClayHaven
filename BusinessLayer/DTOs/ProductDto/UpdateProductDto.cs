using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DTOs.ProductDto
{
   public class UpdateProductDto
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; } = String.Empty;
        public decimal Price { get; set; }
        public int Amount { get; set; }
    }
}
