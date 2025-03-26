using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entity
{
    public class OrderProduct
    {
        public Guid ProductId { get; set; }

        public Product Product { get; set; } 
        public Guid OrderId { get; set; } 

        public Order Order { get; set; }

    }
}
