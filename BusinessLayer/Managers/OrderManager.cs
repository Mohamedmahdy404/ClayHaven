using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Contract;
using BusinessLayer.DTOs.OrderDto;
using BusinessLayer.Mapping;
using DataAccessLayer.Entity;
using DataAccessLayer.Repositories.OrderProductRepo;
using DataAccessLayer.Repositories.OrderRepo;
using DataAccessLayer.Repositories.ProductRepo;

namespace BusinessLayer.Managers
{
  public class OrderManager : IOrderManager
    {
      private readonly IOrderRepo _orderRepo;
      private readonly IOrderProductRepo _orderProductRepo;
      private readonly IProductRepo _productRepo;

      public OrderManager(IOrderRepo orderRepo, IOrderProductRepo orderProductRepo, IProductRepo productRepo)
      {
          _orderRepo = orderRepo;
          _orderProductRepo = orderProductRepo;
          _productRepo = productRepo;
      }

      public async Task<List<GetOrderDto>> GetAllOrder()
      {

          var orders  =await  _orderRepo.GetAllData();
          var orderDtos = orders
              .Select(P => P.OrderToGetOrderDto())
              .ToList(); //Try Pass it as ienmbrable (without Tolist)

          // Fetch all order-product relations in one database call
            var orderProductData = await _orderProductRepo.GetAllDataWithProduct();

            foreach (var order in orderDtos)
            {
               order.ListOfProduct = orderProductData
                  .Where(p => p.OrderId == order.OrderId)
                  .Select(o=>o.Product)
                  .Select(p=>p.ProductToGetListOfPrductDto())
                  .ToList();
            }
          return orderDtos;
      }

      public async Task CreateOrder(CreateOrderDto newOrderDto)
      {
            Guid newOrderId =Guid.NewGuid();

             await _orderRepo.Add(new Order()
             {
                 OrderId = newOrderId,
                 CustomerName = newOrderDto.CustomerName,
                 TotalAmount = await CalulateTotalAmount(newOrderDto.SelectedProductGuisDto)
             });

             foreach (var productId in newOrderDto.SelectedProductGuisDto)
             {
                 await _orderProductRepo.Add(new OrderProduct() { ProductId = productId, OrderId = newOrderId });
             }
      }

      public async Task UpdateOrder(UpdateOrderDto editOrderDto)
      {
          throw new NotImplementedException();
      }

      public async Task RemoveOrder(Guid id)
      {
          await _orderRepo.Remove(id);
         
      }

      public async Task<decimal> CalulateTotalAmount(ICollection<Guid> collectionOfIds)
      {
          decimal TotalAmount = default;
          foreach (var id in collectionOfIds)
          {
              var P = await _productRepo.GetProductById(id);
              TotalAmount += P.Price;

          }
          return TotalAmount;
      }

  }
}
