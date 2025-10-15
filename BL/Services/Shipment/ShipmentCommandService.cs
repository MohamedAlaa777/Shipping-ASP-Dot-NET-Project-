using AutoMapper;
using AutoMapper.QueryableExtensions;
using BL.Contract;
using BL.Contract.Shipment;
using BL.Dtos;
using BL.Services.Shipment;
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
    public class ShipmentCommandService : BaseService<TbShippment, ShippmentDto>, IShipmentCommand
    {
        IUserReceiver _userReceiver;
        IUserSender _userSender;
        ITrackingNumberCreator _trackingCreator;
        IRateCalculator _rateCalculator;
        IUnitOfWork _uow;
        IUserService _userService;
        IGenericRepository<TbShippment> _repo;
        IMapper _mapper;
        IShipmentStatus _shipmentStatus;
        public ShipmentCommandService(IGenericRepository<TbShippment> repo, IMapper mapper,
             IUserService userService, IUserReceiver userReceiver,
             IUserSender userSender, ITrackingNumberCreator trackingCreator
            , IRateCalculator rateCalculator, IShipmentStatus shipmentStatus, IUnitOfWork uow) : base(uow, mapper, userService)
        {
            _uow = uow;
            _repo = repo;
            _mapper = mapper;
            _userReceiver = userReceiver;
            _userSender = userSender;
            _trackingCreator = trackingCreator;
            _rateCalculator = rateCalculator;
            _userService = userService;
            _shipmentStatus = shipmentStatus;
        }

        public async Task Create(ShippmentDto dto)
        {
            try
            {
                await _uow.BeginTransactionAsync();
                // create tracking number
                dto.TrackingNumber = _trackingCreator.Create(dto);
                // calculate date
                dto.ShippingRate = _rateCalculator.Calculate(dto);
                // save sender
                var userId = _userService.GetLoggedInUser();
                if (dto.SenderId == Guid.Empty)
                {
                    dto.UserSender.UserId = userId;
                    var senderResult=await _userSender.Add(dto.UserSender);
                    dto.SenderId = senderResult.Item2;
                }
                // save receiver
                if (dto.ReceiverId == Guid.Empty)
                {
                    dto.UserReceiver.UserId = userId;
                    var reciverResult=await _userReceiver.Add(dto.UserReceiver);
                    dto.ReceiverId = reciverResult.Item2;
                }
                // save shipment
                Guid gShipmentId = Guid.Empty;
                var result =await this.Add(dto);
                gShipmentId = result.Item2;
                // add shipment status
                await _shipmentStatus.Add(gShipmentId, ShipmentStatusEnum.Created);
                await _uow.CommitAsync();
            }
            catch (Exception ex)
            {
                await _uow.RollbackAsync();
                throw new Exception();
            }
        }

        public async Task Edit(ShippmentDto dto)
        {
            try
            {
                await _uow.BeginTransactionAsync();
                // calculate date
                dto.ShippingRate = _rateCalculator.Calculate(dto);
                // save sender
                dto.UserSender.Id = dto.SenderId;
                var senderResult = await _userSender.Update(dto.UserSender);
                // save receiver
                dto.UserReceiver.Id = dto.ReceiverId;
                var reciverResult=await _userReceiver.Update(dto.UserReceiver);
                // save shipment
                await this.Update(dto);
                await _uow.CommitAsync();
            }
            catch (Exception ex)
            {
                await _uow.RollbackAsync();
                throw new Exception();
            }
        }

        public async Task EditFields(Guid id, Action<TbShippment> updateAction)
        {
            await _repo.Update(id, updateAction);
        }
    }
}
