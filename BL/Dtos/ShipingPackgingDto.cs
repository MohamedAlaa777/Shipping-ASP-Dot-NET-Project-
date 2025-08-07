using BL.Dtos.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Dtos
{
    public class ShipingPackgingDto : BaseDto
    {
        public string? ShipingPackgingAname { get; set; }

        public string? ShipingPackgingEname { get; set; }
    }
}
