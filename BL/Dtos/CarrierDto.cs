using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Dtos.Base;

namespace BL.Dtos
{
    public partial class CarrierDto : BaseDto
    {
        public string CarrierName { get; set; } = null!;
    }
}
