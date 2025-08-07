using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Contracts
{
    public interface IViewRepository<T> where T : class
    {
        List<T> GetAll();
        T GetById(Guid id);
        T GetFirstOrDefault(Expression<Func<T, bool>> filter);
        List<T> GetList(Expression<Func<T, bool>> filter);
    }
}
