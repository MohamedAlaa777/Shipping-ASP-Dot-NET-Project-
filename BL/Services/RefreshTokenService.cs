using AutoMapper;
using BL.Contract;
using BL.Dtos;
using DAL.Contracts;
using Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services
{
    public class RefreshTokenService : BaseService<TbRefreshTokens, RefreshTokenDto>, IRefreshTokens
    {
        IGenericRepository<TbRefreshTokens> _repo;
        IMapper _mapper;
        public RefreshTokenService(IGenericRepository<TbRefreshTokens> repo, IMapper mapper,
            IUserService userService) : base(repo, mapper, userService)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<bool> Refresh(RefreshTokenDto tokenDto)
        {
            var tokenList = await _repo.GetList(a => a.UserId == tokenDto.UserId && a.CurrentState == 1);
            foreach (var dbToken in tokenList)
            {
                _repo.ChangeStatus(dbToken.Id, Guid.Parse(tokenDto.UserId), 2);
            }

            var dbTokens = _mapper.Map<RefreshTokenDto, TbRefreshTokens>(tokenDto);
            _repo.Add(dbTokens);
            return true;
        }
    }
}
