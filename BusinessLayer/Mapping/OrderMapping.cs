using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.DTOs.OrderDto;
using BusinessLayer.DTOs.ProductDto;
using BusinessLayer.Service;
using DataAccessLayer.Entity;

namespace BusinessLayer.Mapping
{
   public static class OrderMapping
   {
       //public static ITotalPriceHandler _PriceHandler { get; }

        public static GetOrderDto OrderToGetOrderDto(this Order o)
        {
            return new GetOrderDto()
            {
                OrderId = o.OrderId,
                CustomerName = o.CustomerName,
                Date = o.Date,
                TotalAmount = o.TotalAmount,
                ListOfProduct = new List<GetListOfPrductDto>()
            };
        }


        //public static async Task<Order> CreateOrderDtoToOrder(this CreateOrderDto orderDto,Guid id)
        //{
        //    var y = await _PriceHandler.GetTotalPrice(orderDto.SelectedProductGuisDto);
        //    return new Order()
        //    {
        //        OrderId=id,
        //        CustomerName = orderDto.CustomerName,
        //        TotalAmount = y
        //    };
        //}


        public static Order GetOrderDtoToOrder(this GetOrderDto order)
        {
           return new Order()
            {
                CustomerName = order.CustomerName,
                Date = order.Date,
                OrderId = order.OrderId,
                TotalAmount = order.TotalAmount
            };
        }

        public static Order CreateOrderDtoToOrder(this CreateOrderDto neworder)
        {
            return new Order()
            {
                CustomerName = neworder.CustomerName,
                TotalAmount = neworder.TotalAmount
            };

        }


    }
}
