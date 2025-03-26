using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Context;
using DataAccessLayer.Entity;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repositories.ProductRepo
{
    public class ProductRepo: IProductRepo
    {
        private readonly ApplicationDbContext _dbContext;

        public ProductRepo(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Product>> GetAllProduct()
        {
            return await _dbContext.Products.ToListAsync();
        }

        public async Task<Product?> GetProductById(Guid id)
        {
            return await _dbContext.Products.FirstOrDefaultAsync(p => p.ProductId == id);
        }

        public async Task AddProduct(Product p)
        {
           await _dbContext.Products.AddAsync(p);
           await _dbContext.SaveChangesAsync();
        }


        public async Task UpdateProduct(Product p)
        {
            var CurrentProduct = await GetProductById(p.ProductId);
            if (CurrentProduct != null)
            {
                CurrentProduct.Name = p.Name;
                CurrentProduct.Price = p.Price;
                CurrentProduct.Amount = p.Amount;
            }

            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteProduct(Guid id)
        {
           var x= await _dbContext.Products.FirstOrDefaultAsync(p => p.ProductId == id);
           if (x != null)
               _dbContext.Products.Remove(x);
           await _dbContext.SaveChangesAsync();
        }
    }
}
