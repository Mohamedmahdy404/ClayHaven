using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.DTOs.OrderDto;

namespace BusinessLayer.Contract
{
  public  interface IOrderManager
  {
      public Task CreateOrder(CreateOrderDto newOrderDto);

      public Task<List<GetOrderDto>> GetAllOrder();

      public Task UpdateOrder(UpdateOrderDto editOrderDto);

      public Task RemoveOrder(Guid id);

      public Task<Decimal> CalulateTotalAmount(ICollection<Guid> collectionOfIds);



  }
}
