using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DTOs.OrderDto
{
  public  class UpdateOrderDto
    {
        public Guid OrderId { get; set; } = Guid.NewGuid();
        public string CustomerName { get; set; } = String.Empty;
        public int TotalAmount { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
    }
}
