using BL.Contract;
using BL.Contract.Shipment;
using BL.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services.Shipment
{
    public class ReturnedShipment : IShipmentStateHandler
    {
        IShipmentCommand _shipment;
        IShipmentStatus _status;
        public ReturnedShipment(IShipmentCommand shipment, IShipmentStatus status) 
        {
            _shipment=shipment;
            _status=status;
        }

        public ShipmentStatusEnum TargetState { get => ShipmentStatusEnum.Returned; }

        public async Task HandleState(ShippmentDto shipment)
        {
            await _shipment.ChangeStatus(shipment.Id, (int)TargetState);
            await _status.Add(shipment.Id, TargetState);
        }
    }
}
