using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using DataAccessLayer.Repositories.ProductRepo;

namespace BusinessLayer.Service
{
  public  class  TotalPriceHandler: ITotalPriceHandler
    {
      private  readonly IProductRepo _productRepo;
      public TotalPriceHandler(IProductRepo productRepo)
      {
          _productRepo = productRepo ?? throw new ArgumentNullException(nameof(productRepo));
      }
        public  async Task<decimal> GetTotalPrice( ICollection<Guid> GuidList)
        {
            decimal TotalAmount = default;
            foreach(var guid in GuidList)
            {
              var Product =await _productRepo.GetProductById(guid);
              TotalAmount += Product.Price;
            }

            return TotalAmount;
        }


    }
}
