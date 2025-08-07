using AutoMapper;
using BL.Contract;
using BL.Contract.Shipment;
using BL.Dtos;
using DAL.Contracts;
using DAL.Entities;
using DAL.Repositories;
using Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services
{
    public class ShipmentService : BaseService<TbShippment, ShippmentDto>, IShipment
    {
        IUserReceiver _userReceiver;
        IUserSender _userSender;
        ITrackingNumberCreator _trackingCreator;
        IRateCalculator _rateCalculator;
        IUnitOfWork _uow;
        IUserService _userService;
        IGenericRepository<TbShippment> _repo;
        IMapper _mapper;
        public ShipmentService(IGenericRepository<TbShippment> repo, IMapper mapper,
             IUserService userService, IUserReceiver userReceiver,
             IUserSender userSender, ITrackingNumberCreator trackingCreator
            , IRateCalculator rateCalculator, IUnitOfWork uow) : base(uow, mapper, userService)
        {
            _uow = uow;
            _repo = repo;
            _mapper = mapper;
            _userReceiver = userReceiver;
            _userSender = userSender;
            _trackingCreator = trackingCreator;
            _rateCalculator = rateCalculator;
            _userService = userService;
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
                    Guid gSenderId = Guid.Empty;
                    dto.UserSender.UserId = userId;
                    _userSender.Add(dto.UserSender, out gSenderId);
                    dto.SenderId = gSenderId;
                }
                // save receiver
                if (dto.ReceiverId == Guid.Empty)
                {
                    Guid gReciverId = Guid.Empty;
                    dto.UserReceiver.UserId = userId;
                    _userReceiver.Add(dto.UserReceiver, out gReciverId);
                    dto.ReceiverId = gReciverId;
                }
                // save shipment
                //Guid gShipmentId = Guid.Empty;
                this.Add(dto);
                // add shipment status
                //ShippmentStatusDto status = new ShippmentStatusDto();
                //status.ShippmentId = gShipmentId;
                //status.CurrentState = (int)ShipmentStatusEnum.Created;
                //_shipmentStatus.Add(status);
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
                _userSender.Update(dto.UserSender);
                // save receiver
                dto.UserReceiver.Id = dto.ReceiverId;
                _userReceiver.Update(dto.UserReceiver);
                // save shipment
                this.Update(dto);
                await _uow.CommitAsync();
            }
            catch (Exception ex)
            {
                await _uow.RollbackAsync();
                throw new Exception();
            }
        }

        public async Task<List<ShippmentDto>> GetShipments()
        {
            try
            {
                var userId = _userService.GetLoggedInUser();

                var shipments = await _repo.GetList(
                    filter: a => a.CreatedBy == userId,
                    selector: a => new ShippmentDto
                    {
                        Id = a.Id,
                        ShipingDate = a.ShipingDate,
                        DelivryDate = a.DelivryDate,
                        SenderId = a.SenderId,
                        ReceiverId = a.ReceiverId,
                        ShippingTypeId = a.ShippingTypeId,
                        ShipingPackgingId = a.ShipingPackgingId,
                        Width = a.Width,
                        Height = a.Height,
                        Weight = a.Weight,
                        Length = a.Length,
                        PackageValue = a.PackageValue,
                        ShippingRate = a.ShippingRate,
                        PaymentMethodId = a.PaymentMethodId,
                        UserSubscriptionId = a.UserSubscriptionId,
                        TrackingNumber = a.TrackingNumber,
                        ReferenceId = a.ReferenceId,

                        UserSender = new UserSenderDto
                        {
                            Id = a.Sender.Id,
                            SenderName = a.Sender.SenderName,
                            Email = a.Sender.Email,
                            Phone = a.Sender.Phone
                        },
                        UserReceiver = new UserReceiverDto
                        {
                            Id = a.Receiver.Id,
                            ReceiverName = a.Receiver.ReceiverName,
                            Email = a.Receiver.Email,
                            Phone = a.Receiver.Phone
                        }
                    },
                    orderBy: a => a.CreatedDate,
                    isDescending: true,
                    a => a.Sender, a => a.Receiver
                );

                return shipments;
            }
            catch (Exception ex)
            {
                throw new Exception("Error while getting shipments", ex);
            }
        }

        //public async Task<PagedResult<ShippmentDto>> GetShipments(int pageNumber, int pageSize)
        //{
        //    try
        //    {
        //        var userId = _userService.GetLoggedInUser();

        //        var result = await _repo.GetPagedList(
        //            pageNumber: pageNumber,
        //            pageSize: pageSize,
        //            filter: a => a.CreatedBy == userId && a.CurrentState > 0,
        //            selector: a => new ShipmentDto
        //            {
        //                Id = a.Id,
        //                ShipingDate = a.ShipingDate,
        //                DelivryDate = a.DelivryDate,
        //                SenderId = a.SenderId,
        //                ReceiverId = a.ReceiverId,
        //                ShippingTypeId = a.ShippingTypeId,
        //                ShipingPackgingId = a.ShipingPackgingId,
        //                Width = a.Width,
        //                Height = a.Height,
        //                Weight = a.Weight,
        //                Length = a.Length,
        //                PackageValue = a.PackageValue,
        //                ShippingRate = a.ShippingRate,
        //                PaymentMethodId = a.PaymentMethodId,
        //                UserSubscriptionId = a.UserSubscriptionId,
        //                TrackingNumber = a.TrackingNumber,
        //                ReferenceId = a.ReferenceId,
        //                UserSender = new UserSenderDto
        //                {
        //                    Id = a.Sender.Id,
        //                    SenderName = a.Sender.SenderName,
        //                    Email = a.Sender.Email,
        //                    Phone = a.Sender.Phone
        //                },
        //                UserReceiver = new UserReceiverDto
        //                {
        //                    Id = a.Receiver.Id,
        //                    ReceiverName = a.Receiver.ReceiverName,
        //                    Email = a.Receiver.Email,
        //                    Phone = a.Receiver.Phone
        //                }
        //            },
        //            orderBy: a => a.CreatedDate,
        //            isDescending: true,
        //            a => a.Sender, a => a.Receiver
        //        );

        //        return result;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("Error while getting shipments", ex);
        //    }
        //}

        //public async Task<ShippmentDto> GetShipment(Guid id)
        //{
        //    try
        //    {
        //        var userId = _userService.GetLoggedInUser();

        //        var shipments = await _repo.GetList(
        //            filter: a => a.Id == id && a.CreatedBy == userId,
        //            selector: a => new ShipmentDto
        //            {
        //                Id = a.Id,
        //                ShipingDate = a.ShipingDate,
        //                DelivryDate = a.DelivryDate,
        //                SenderId = a.SenderId,
        //                ReceiverId = a.ReceiverId,
        //                ShippingTypeId = a.ShippingTypeId,
        //                ShipingPackgingId = a.ShipingPackgingId,
        //                Width = a.Width,
        //                Height = a.Height,
        //                Weight = a.Weight,
        //                Length = a.Length,
        //                PackageValue = a.PackageValue,
        //                ShippingRate = a.ShippingRate,
        //                PaymentMethodId = a.PaymentMethodId,
        //                UserSubscriptionId = a.UserSubscriptionId,
        //                TrackingNumber = a.TrackingNumber,
        //                ReferenceId = a.ReferenceId,

        //                UserSender = new UserSenderDto
        //                {
        //                    Id = a.Sender.Id,
        //                    SenderName = a.Sender.SenderName,
        //                    Email = a.Sender.Email,
        //                    Phone = a.Sender.Phone,
        //                    Address = a.Sender.Address,
        //                    Contact = a.Sender.Contact,
        //                    PostalCode = a.Sender.PostalCode,
        //                    OtherAddress = a.Sender.OtherAddress,
        //                    CityId = a.Sender.CityId,
        //                    CountryId = a.Sender.City.CountryId
        //                },
        //                UserReceiver = new UserReceiverDto
        //                {
        //                    Id = a.Receiver.Id,
        //                    ReceiverName = a.Receiver.ReceiverName,
        //                    Email = a.Receiver.Email,
        //                    Phone = a.Receiver.Phone,
        //                    Address = a.Receiver.Address,
        //                    Contact = a.Receiver.Contact,
        //                    PostalCode = a.Receiver.PostalCode,
        //                    OtherAddress = a.Receiver.OtherAddress,
        //                    CityId = a.Receiver.CityId,
        //                    CountryId = a.Receiver.City.CountryId
        //                }
        //            },
        //            orderBy: a => a.CreatedDate,
        //            isDescending: true,
        //            a => a.Sender,
        //            a => a.Sender.City,
        //            a => a.Sender.City.Country,
        //            a => a.Receiver,
        //            a => a.Receiver.City,
        //            a => a.Receiver.City.Country
        //        );

        //        return shipments.FirstOrDefault();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("Error while getting shipment", ex);
        //    }
        //}



    }
}
