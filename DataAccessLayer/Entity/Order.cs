using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entity
{
    public class Order
    {
        public Guid OrderId { get; set; } = Guid.NewGuid();
        public string CustomerName { get; set; } =String.Empty;
        public Decimal TotalAmount { get; set; }
        public DateTime Date { get; set; } =DateTime.Now;

        public ICollection<OrderProduct> ListOfProduct = new List<OrderProduct>();
    }
}
