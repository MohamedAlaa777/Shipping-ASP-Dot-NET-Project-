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

        public async Task<List<CityDto>> GetAllCitites()
        {
            var cities = await _ViewRepo.GetList(a => a.CurrentState == 1);
            return _mapper.Map<List<VwCities>, List<CityDto>>(cities);
        }

        public async Task<List<CityDto>> GetByCountry(Guid countryId)
        {
            var cities = await _ViewRepo.GetList(a => a.CurrentState == 1 &&
            a.CountryId == countryId);
            return _mapper.Map<List<VwCities>, List<CityDto>>(cities);
        }


    }
}
