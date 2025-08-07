using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Mapping
{
    public class AutoMapper : IMapper
    {
        // we create this interface to be generic if we need to change the package of automapper don't affect
        // in the BaseService class
        private readonly IMapper _mapper;
        public AutoMapper(IMapper mapper)
        {
            _mapper = mapper;
        }

        public TDestination Map<TSource, TDestination>()
        {
            return _mapper.Map<TSource, TDestination>();
        }
    }
}
