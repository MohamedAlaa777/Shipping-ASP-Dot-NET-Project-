using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Dtos.Base;

namespace BL.Dtos
{
    public partial class PaymentMethodDto : BaseDto
    {
        public string? MethdAname { get; set; }
        public string? MethodEname { get; set; }
        public float? Commission { get; set; }
    }
}
