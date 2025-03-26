using BusinessLayer.DTOs.OrderDto;
using BusinessLayer.DTOs.ProductDto;
using PresentationLayer.Actions_Request.Order;
using PresentationLayer.VMs.Order;

namespace PresentationLayer.Mapping
{
    public static class OrderMapping
    {
        public static CreateOrderDto CreateOrderActionToCreateOrderDto(this CreateOrderAction o)
        {
            return new CreateOrderDto()
            {
                CustomerName = o.CustomerName,
                SelectedProductGuisDto = o.SelectedProductsId
                    .Select(id =>
                    {
                        if (!Guid.TryParse(id, out Guid guid))
                        {
                            throw new FormatException($"Invalid GUID format: {id}");
                        }
                        return guid;
                    })
                    .ToList() // Convert to a List<Guid>


                //SelectedProductGuisDto = o.SelectedProductsId
                //    .Select(id => Guid.TryParse(id, out Guid guid) ? guid : Guid.Empty) // Convert string IDs to GUIDs
                //    .Where(guid => guid != Guid.Empty) // Filter out invalid GUIDs
                //    .ToList() // Convert to a List<Guid>
            };
        }


        public static GetOrderVM GetOrderDtoToGetOrderVM(this GetOrderDto orderDto)
        {
            var ListOfProduct = new List<GetListOfPrductDto>();
            return new GetOrderVM()
            {
                CustomerName = orderDto.CustomerName,
                Date = orderDto.Date,
                OrderId = orderDto.OrderId,
                TotalAmount = orderDto.TotalAmount,
                ListOfProduct = orderDto.ListOfProduct

            };
        }

    }
}
