using AutoMapper;
using BL.Contract;
using BL.Dtos;
using DAL.Contracts;
using DAL.Entities;
using DAL.Repositories;
using Domains;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services
{
    public class UserReceiverService : BaseService<TbUserReceiver, UserReceiverDto>,IUserReceiver
    {
        IUnitOfWork _uow;
        public UserReceiverService(IGenericRepository<TbUserReceiver> repo,IMapper mapper,
             IUserService userService, IUnitOfWork uow) : base(uow, mapper, userService)
        {
            _uow = uow;
        }
    }
}
