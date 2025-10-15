using AutoMapper;
using BL.Contract;
using BL.Contract.Shipment;
using BL.Dtos;
using Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services.Shipment
{
    public class ShippedShipment : IShipmentStateHandler
    {
        IShipmentCommand _shipment;
        IShipmentStatus _status;
        IUserService _userService;
        public ShippedShipment(IShipmentCommand shipment, IShipmentStatus status,
            IUserService IUserService)
        {
            _shipment = shipment;
            _status = status;
            _userService = IUserService;
        }

        public ShipmentStatusEnum TargetState { get => ShipmentStatusEnum.Shipped; }

        public async Task HandleState(ShippmentDto shipment)
        {
            var userId = _userService.GetLoggedInUser();
            await _shipment.EditFields(shipment.Id, a =>
            {
                a.DelivryDate = shipment.DelivryDate;
                a.CurrentState = (int)TargetState;
                a.UpdatedBy = userId;
                a.UpdatedDate = DateTime.UtcNow;
            });
            await _shipment.ChangeStatus(shipment.Id, (int)TargetState);
            await _status.Add(shipment.Id, TargetState);
        }
    }
}
