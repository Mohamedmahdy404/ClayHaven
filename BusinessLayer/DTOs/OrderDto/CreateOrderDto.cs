using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DTOs.OrderDto
{
  public class CreateOrderDto
    {

        public string CustomerName { get; set; } = String.Empty;
        public decimal TotalAmount { get; set; } ///can Eemove

        public ICollection<Guid> SelectedProductGuisDto { get; set; } = new List<Guid>();

    }
}
