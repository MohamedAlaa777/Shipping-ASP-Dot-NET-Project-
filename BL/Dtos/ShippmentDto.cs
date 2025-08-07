using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Dtos.Base;

namespace BL.Dtos
{
    public partial class ShippmentDto : BaseDto
    {
        public DateTime ShipingDate { get; set; }
        public DateTime DelivryDate { get; set; }

        public Guid SenderId { get; set; }
        public UserSenderDto UserSender { get; set; } = new UserSenderDto();
        public Guid ReceiverId { get; set; }
        public UserReceiverDto UserReceiver { get; set; } = new UserReceiverDto();
        public Guid ShippingTypeId { get; set; }
        public Guid? ShipingPackgingId { get; set; }

        public double Width { get; set; }

        public double Height { get; set; }

        public double Weight { get; set; }

        public double Length { get; set; }

        public decimal PackageValue { get; set; }

        public decimal ShippingRate { get; set; }

        public Guid? PaymentMethodId { get; set; }

        public Guid? UserSubscriptionId { get; set; }

        public double? TrackingNumber { get; set; }

        public Guid? ReferenceId { get; set; }
    }
}
