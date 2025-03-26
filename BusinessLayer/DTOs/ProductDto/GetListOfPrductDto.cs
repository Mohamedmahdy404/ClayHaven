using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DTOs.ProductDto
{
   public class GetListOfPrductDto
    {
   
        public string Name { get; set; } = String.Empty;
        public decimal Price { get; set; }
        public string PhotoLocation { get; set; }

    }
}
