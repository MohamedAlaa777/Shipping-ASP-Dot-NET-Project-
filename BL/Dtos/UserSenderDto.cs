using BL.Dtos.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Dtos
{
    public partial class UserSenderDto : BaseDto
    {
        public Guid UserId { get; set; }

        public string SenderName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Phone { get; set; } = null!;
        public string PostalCode { get; set; } = null!;
        public string Contact { get; set; } = null!;
        public string OtherAddress { get; set; } = null!;
        public bool IsDefault { get; set; }
        public Guid CityId { get; set; }

        public string Address { get; set; } = null!;
    }
}
