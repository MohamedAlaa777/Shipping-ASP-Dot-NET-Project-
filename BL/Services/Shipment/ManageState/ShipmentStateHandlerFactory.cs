using BL.Contract.Shipment;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services.Shipment
{
    public class ShipmentStateHandlerFactory : IShipmentStateHandlerFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public ShipmentStateHandlerFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IShipmentStateHandler GetHandler(ShipmentStatusEnum status)
        {
            return status switch
            {
                ShipmentStatusEnum.Approved => _serviceProvider.GetRequiredService<ApproveShipment>(),
                ShipmentStatusEnum.ReadyForShip => _serviceProvider.GetRequiredService<ReadyShipment>(),
                ShipmentStatusEnum.Shipped => _serviceProvider.GetRequiredService<ShippedShipment>(),
                ShipmentStatusEnum.Delivered => _serviceProvider.GetRequiredService<DelivredShipment>(),
                ShipmentStatusEnum.Returned => _serviceProvider.GetRequiredService<ReturnedShipment>(),
                _ => throw new NotImplementedException($"No handler implemented for state: {status}")
            };
        }
    }

}
