using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Contract;
using BusinessLayer.DTOs.ProductDto;
using BusinessLayer.Mapping;
using DataAccessLayer.Repositories.ProductRepo;

namespace BusinessLayer.Managers
{
    public class ProductManager : IProductManager
    {
        private readonly IProductRepo _productRepo;

        public ProductManager(IProductRepo productRepo)
        {
            _productRepo = productRepo;
        }



        public async Task<List<GetProductDto>> GetAllProduct()
        {
            var x = await _productRepo.GetAllProduct();
            return x.Select(p => p.ToProductDto()).ToList();
        }

        public async Task<GetProductDto?> GetProductById(Guid id)
        {
            var x = await _productRepo.GetProductById(id);
            return x.ToProductDto();
        }

        public async Task AddProduct(AddProductDto p)
        {
           await _productRepo.AddProduct(p.ToProduct());
        }

        public async Task UpdateProduct(UpdateProductDto p)
        {
            
          await   _productRepo.UpdateProduct(p.UpdateDtoToProudct());
        }

        public async Task DeleteProduct(Guid id)
        {
            await _productRepo.DeleteProduct(id);
        }
    }
}
