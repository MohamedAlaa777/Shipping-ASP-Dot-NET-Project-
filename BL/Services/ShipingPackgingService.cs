using AutoMapper;
using BL.Contract;
using BL.Dtos;
using DAL.Contracts;
using DAL.Repositories;
using Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services
{
    public class ShipingPackgingService : BaseService<TbShipingPackging, ShipingPackgingDto>,IPackgingTypes
    {
        public ShipingPackgingService(IGenericRepository<TbShipingPackging> repo,IMapper mapper,
             IUserService userService) : base(repo,mapper, userService)
        {

        }
    }
}
