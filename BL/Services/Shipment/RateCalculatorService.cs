using BL.Contract.Shipment;
using BL.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services.Shipment
{
    public class RateCalculatorService : IRateCalculator
    {
        public decimal Calculate(ShippmentDto dto)
        {
            return 4545;
        }
    }
}
