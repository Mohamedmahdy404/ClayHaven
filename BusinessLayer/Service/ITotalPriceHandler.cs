using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Service
{
   public interface ITotalPriceHandler
   {
       public Task<decimal> GetTotalPrice(ICollection<Guid> GuidList);
   }
}
