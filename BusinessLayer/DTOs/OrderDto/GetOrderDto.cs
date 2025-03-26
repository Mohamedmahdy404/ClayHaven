using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.DTOs.ProductDto;
using DataAccessLayer.Entity;

namespace BusinessLayer.DTOs.OrderDto
{
   public class GetOrderDto
    {
        public Guid OrderId { get; set; } = Guid.NewGuid();
        public string CustomerName { get; set; } = String.Empty;
        public Decimal TotalAmount { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public ICollection<GetListOfPrductDto> ListOfProduct { get; set; } = new List<GetListOfPrductDto>();

    }
}
