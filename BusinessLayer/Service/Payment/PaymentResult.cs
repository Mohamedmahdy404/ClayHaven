using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Service.Payment
{
 public   class PaymentResult
    {
        public bool Success { get; set; }
        public string ChargeId { get; set; }

    }
}
