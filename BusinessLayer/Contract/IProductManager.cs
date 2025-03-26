using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.DTOs.ProductDto;
using DataAccessLayer.Entity;

namespace BusinessLayer.Contract
{
  public  interface IProductManager
    {
        public Task<List<GetProductDto>> GetAllProduct();
        public Task<GetProductDto?> GetProductById(Guid id);

        public Task AddProduct(AddProductDto p);
        public Task UpdateProduct(UpdateProductDto p);
        public Task DeleteProduct(Guid id);

    }
}
