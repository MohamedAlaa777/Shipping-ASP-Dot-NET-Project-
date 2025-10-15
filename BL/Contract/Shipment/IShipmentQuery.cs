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
    public interface IShipmentQuery : IBaseService<TbShippment,ShippmentDto>
    {
        public Task<List<ShippmentDto>> GetShipments();
        public Task<PagedResult<ShippmentDto>> GetShipments(int pageNumber, int pageSize,bool isUserData,ShipmentStatusEnum? status);
        public Task<PagedResult<ShippmentDto>> GetAllShipments(int pageNumber, int pageSize);
        public Task<ShippmentDto> GetShipment(Guid id);
    }
}
