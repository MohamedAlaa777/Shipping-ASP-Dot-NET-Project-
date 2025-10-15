using AutoMapper;
using AutoMapper.QueryableExtensions;
using BL.Contract;
using BL.Contract.Shipment;
using BL.Dtos;
using DAL.Contracts;
using DAL.Entities;
using DAL.Models;
using DAL.Repositories;
using Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services
{
    public class ShipmentStatusService : BaseService<TbShipmentStatus, ShippmentStatusDto>, IShipmentStatus
    {
        IUnitOfWork _uow;
        IUserService _userService;
        IGenericRepository<TbShipmentStatus> _repo;
        IMapper _mapper;
        public ShipmentStatusService(IGenericRepository<TbShipmentStatus> repo, IMapper mapper,
             IUserService userService, IUnitOfWork uow) : base(uow, mapper, userService)
        {
            _uow = uow;
            _repo = repo;
            _mapper = mapper;
            _userService = userService;
        }

        public async Task<(bool, Guid)> Add(Guid shipmentId, ShipmentStatusEnum status)
        {
            ShippmentStatusDto oStatus = new ShippmentStatusDto();
            oStatus.ShippmentId = shipmentId;
            oStatus.CurrentState = (int)status;
            var dbObject = _mapper.Map<ShippmentStatusDto, TbShipmentStatus>(oStatus);
            dbObject.CreatedBy = _userService.GetLoggedInUser();
            //dbObject.CurrentState = 1;
            return await _repo.Add(dbObject);
        }
    }
}
