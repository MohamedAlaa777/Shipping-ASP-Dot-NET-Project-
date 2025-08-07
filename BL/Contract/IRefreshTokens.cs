using BL.Dtos;
using Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Contract
{
    public interface IRefreshTokens : IBaseService<TbRefreshTokens, RefreshTokenDto>
    {
        public Task<bool> Refresh(RefreshTokenDto tokenDto);

    }
}
