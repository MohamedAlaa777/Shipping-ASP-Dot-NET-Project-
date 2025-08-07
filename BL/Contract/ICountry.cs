using BL.Dtos;
using DAL.Entities;
using Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Contract
{
    // we create this interface for (readable) injection & if we need to add new features
    public interface ICountry : IBaseService<TbCountry,CountryDto>
    {

    }
}
