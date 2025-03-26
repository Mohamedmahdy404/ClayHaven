using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Entity;

namespace DataAccessLayer.Repositories.ProductRepo
{
  public  interface IProductRepo
  {

      public Task<List<Product>> GetAllProduct();
      public Task<Product?> GetProductById(Guid id);

      public Task AddProduct(Product p);
      public Task UpdateProduct(Product p);
      public Task DeleteProduct(Guid id);


  }
}
