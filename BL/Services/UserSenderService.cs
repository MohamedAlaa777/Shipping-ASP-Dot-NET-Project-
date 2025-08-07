using AutoMapper;
using BL.Contract;
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
    public class UserSenderService : BaseService<TbUserSebder, UserSenderDto>,IUserSender
    {
        IUnitOfWork _uow;
        public UserSenderService(IGenericRepository<TbUserSebder> repo,IMapper mapper,
             IUserService userService, IUnitOfWork uow) : base(uow, mapper, userService)
        {
            _uow = uow;
        }
    }
}
