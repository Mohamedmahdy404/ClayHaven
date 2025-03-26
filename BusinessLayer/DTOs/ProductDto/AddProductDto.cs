using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace BusinessLayer.DTOs.ProductDto
{
  public  class AddProductDto
    {
       
        public string Name { get; set; } = String.Empty;
        public decimal Price { get; set; }
        public int Amount { get; set; }
        public IFormFile? Picture { get; set; } 


    }
}
