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
    public interface IShipmentCommand : IBaseService<TbShippment,ShippmentDto>
    {
        public Task Create(ShippmentDto dto);
        public Task Edit(ShippmentDto dto);
        public Task EditFields(Guid id, Action<TbShippment> updateAction);
    }
}
