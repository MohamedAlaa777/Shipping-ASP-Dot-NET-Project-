using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services
{
    public enum ShipmentStatusEnum
    {
        Deleted=0,
        Created=1,
        Approved=2,
        ReadyForShip=3,
        //from here no edit or delete
        Shipped=4,
        Delivered=5,
        Returned=6
    }
}
