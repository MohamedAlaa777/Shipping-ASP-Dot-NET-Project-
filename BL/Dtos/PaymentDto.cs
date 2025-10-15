using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Dtos
{
    public class PaymentDto
    {
        public string OrderId { get; set; }
        public decimal Amount { get; set; }
    }
}
