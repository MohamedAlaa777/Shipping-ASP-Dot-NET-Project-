using AutoMapper;
using BL.Contract;
using BL.Dtos;
using DAL.Contracts;
using DAL.Entities;
using Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services
{
    public class ShippingTypeService :BaseService<TbShippingType,ShippingTypeDto>, IShippingType
    {
        public ShippingTypeService(IGenericRepository<TbShippingType> repo,IMapper mapper,
            IUserService userService) : base(repo,mapper,userService)
        {
         
        }
       
    }
}
