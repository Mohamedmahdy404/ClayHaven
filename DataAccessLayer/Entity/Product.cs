using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entity
{
   public class Product
    {
        public Guid ProductId { get; set; }  = Guid.NewGuid();
        public string Name { get; set; }  = String.Empty;
        public decimal Price { get; set; }
        public int Amount { get; set; }
        public string PhotoLocation { get; set; }

        public ICollection<OrderProduct> ListOfProduct = new List<OrderProduct>();


    }
}
