using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Entity;

namespace BusinessLayer.DTOs.OrderProductDto
{
  public class OrderPrductDto
    {
        public Guid ProductId { get; set; }
        public Guid OrderId { get; set; }

    }
}
