using BL.Dtos;
using BL.Services;
using DAL.Entities;
using DAL.Models;
using Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Contract
{
    public interface IShipmentStatus : IBaseService<TbShipmentStatus,ShippmentStatusDto>
    {
        public Task<(bool, Guid)> Add(Guid shipmentId, ShipmentStatusEnum status);
    }
}
