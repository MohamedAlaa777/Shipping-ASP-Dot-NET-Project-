using Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Contract
{
    public interface IBaseService<T,DTO>
    {
        List<DTO> GetAll();
        DTO GetById(Guid id);
        bool Add(DTO entity);
        bool Add(DTO entity, out Guid id);
        bool Update(DTO entity);
        bool ChangeStatus(Guid id, int status = 1);
    }
}
