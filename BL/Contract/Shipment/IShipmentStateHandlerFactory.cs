using BL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Contract.Shipment
{
    //creational design pattern to get target object
    public interface IShipmentStateHandlerFactory
    {
        IShipmentStateHandler GetHandler(ShipmentStatusEnum status);
    }

}
