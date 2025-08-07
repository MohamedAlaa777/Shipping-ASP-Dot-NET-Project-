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
    public class CountryService : BaseService<TbCountry,CountryDto>, ICountry
    {
        public CountryService(IGenericRepository<TbCountry> repo,IMapper mapper,
            IUserService userService) : base(repo,mapper,userService)
        {
         
        }
       
    }
}
