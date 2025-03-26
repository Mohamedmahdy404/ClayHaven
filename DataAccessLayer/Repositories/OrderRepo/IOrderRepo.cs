using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Entity;
using DataAccessLayer.Repositories.Generic;

namespace DataAccessLayer.Repositories.OrderRepo
{
  public  interface IOrderRepo: IGenericRepo<Order>
    {

        Task<List<Order>> GetAllData();
        Task<Order> GetById(Guid id);
        Task Add(Order entity);
        Task Update(Order entity);
        Task Remove(Guid id);
    }
}
