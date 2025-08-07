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
    public class PaymentMethodsService : BaseService<TbPaymentMethod,PaymentMethodDto>,IPaymentMethods
    {
        public PaymentMethodsService(IGenericRepository<TbPaymentMethod> repo,IMapper mapper,
             IUserService userService) : base(repo,mapper, userService)
        {

        }
    }
}
