using BL.Dtos;
using BL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Contract.Shipment
{
    //strategy design pattern
    // it uses when you don,t know any service is needed 
    public interface IShipmentStateHandler
    {
        public ShipmentStatusEnum TargetState { get; }
        public Task HandleState(ShippmentDto shipment);
    }
}
