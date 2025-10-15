using BL.Dtos;
using Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Contract
{
    //we make this interface bec, the cricler injection happen as (infint loop) between userservce and refreshtoken
    //so we cut {GetByToken(string token)}=> method from refreshtoken to this(RefreshTokenRetriver)
    //now we don't use (IRefreshTokenRetriver) bec, in past we get user id from refresh token but now we get user id from access token
    public interface IRefreshTokenRetriver
    {
        public Task<RefreshTokenDto> GetByToken(string token);
    }
}
