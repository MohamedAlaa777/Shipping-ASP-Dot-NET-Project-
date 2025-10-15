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
    public class ApproveShipment : IShipmentStateHandler
    {
        IShipmentCommand _shipment;
        IShipmentStatus _status;
        public ApproveShipment(IShipmentCommand shipment, IShipmentStatus status) 
        {
            _shipment=shipment;
            _status=status;
        }

        public ShipmentStatusEnum TargetState { get => ShipmentStatusEnum.Approved; }

        public async Task HandleState(ShippmentDto shipment)
        {
            await _shipment.Edit(shipment);
            await _shipment.ChangeStatus(shipment.Id, (int)TargetState);
            await _status.Add(shipment.Id, TargetState);
        }
    }
}
