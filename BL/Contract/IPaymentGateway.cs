using BL.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Contract
{
    public interface IPaymentGateway
    {
        public Task<(string, bool)> CreateOrder(CreatePaymentRequest requestData);

        public Task<(string, bool)> CaptureOrder(string orderId);
    }
}
