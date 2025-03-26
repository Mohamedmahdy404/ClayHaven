 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Entity;
using DataAccessLayer.Repositories.Generic;

namespace DataAccessLayer.Repositories.OrderProductRepo
{
 public interface IOrderProductRepo : IGenericRepo<OrderProduct>
 {
     public Task<List<OrderProduct>> GetAllDataWithProduct();

 }
}
