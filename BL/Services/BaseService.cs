using AutoMapper;
using BL.Contract;
using DAL.Contracts;
using Domains;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BL.Services
{
    public class BaseService<T, DTO> : IBaseService<T, DTO> where T : BaseTable
    {
        readonly IGenericRepository<T> _repo;
        readonly IMapper _mapper;
        readonly IUserService _userService;
        readonly IUnitOfWork _UnitOfWork;
        public BaseService(IGenericRepository<T> repo, IMapper mapper,
            IUserService userService)
        {
            _repo = repo;
            _mapper = mapper;
            _userService = userService;
        }
        public BaseService(IUnitOfWork unitofwork, IMapper mapper,
            IUserService userService)
        {
            _UnitOfWork = unitofwork;
            _repo = unitofwork.Repository<T>();
            _mapper = mapper;
            _userService = userService;
        }
        // from distination to source 
        public async Task<(bool, Guid)> Add(DTO entity)
        {
            var dbObject = _mapper.Map<DTO, T>(entity);
            dbObject.CreatedBy = _userService.GetLoggedInUser();
            dbObject.CurrentState = 1;
            var result = await _repo.Add(dbObject);
            return result;
        }
        // from distination to source 
        public async Task<bool> Update(DTO entity)
        {
            var dbObject = _mapper.Map<DTO, T>(entity);
            dbObject.UpdatedBy = _userService.GetLoggedInUser();
            return await _repo.Update(dbObject);
        }

        public async Task<bool> ChangeStatus(Guid id, int status = 1)
        {
            return await _repo.ChangeStatus(id, _userService.GetLoggedInUser(), status);
        }
        // from source to distination
        public async Task<List<DTO>> GetAll()
        {
            var list = await _repo.GetAll();
            return _mapper.Map<List<T>, List<DTO>>(list);
        }

        // from source to distination
        public async Task<DTO> GetById(Guid id)
        {
            var obj = await _repo.GetById(id);
            return _mapper.Map<T, DTO>(obj);
        }


    }
}
