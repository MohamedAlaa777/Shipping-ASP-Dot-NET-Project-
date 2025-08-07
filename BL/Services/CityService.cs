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
    public class CityService : BaseService<TbCity, CityDto>, ICity
    {
        IViewRepository<VwCities> _ViewRepo;
        IMapper _mapper;
        public CityService(IGenericRepository<TbCity> repo, IMapper mapper,
            IUserService userService, IViewRepository<VwCities> viewRepo) : base(repo, mapper, userService)
        {
            _ViewRepo = viewRepo;
            _mapper = mapper;
        }

        public List<CityDto> GetAllCitites()
        {
            var cities = _ViewRepo.GetList(a=>a.CurrentState==1).ToList();
            return _mapper.Map<List<VwCities>, List<CityDto>>(cities);
        }

        public List<CityDto> GetByCountry(Guid countryId)
        {
            var cities = _ViewRepo.GetList(a => a.CurrentState == 1 &&
            a.CountryId == countryId).ToList();
            return _mapper.Map<List<VwCities>, List<CityDto>>(cities);
        }


    }
}
