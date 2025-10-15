using System;
using AppResource;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using BL.Dtos.Base;

namespace BL.Dtos
{
    public partial class ShippmentDto : BaseDto
    {
        [Required(ErrorMessageResourceName = "FactorRequired", ErrorMessageResourceType = typeof(Shipping))]
        [DataType(DataType.Date)]
        public DateTime ShipingDate { get; set; }

        [Required(ErrorMessageResourceName = "FactorRequired", ErrorMessageResourceType = typeof(Shipping))]
        [DataType(DataType.Date)]
        public DateTime DelivryDate { get; set; }

        [Required(ErrorMessageResourceName = "FirstNameRequired", ErrorMessageResourceType = typeof(Shipping))]
        public Guid SenderId { get; set; }

        public UserSenderDto UserSender { get; set; } = new UserSenderDto();

        [Required(ErrorMessageResourceName = "FirstNameRequired", ErrorMessageResourceType = typeof(Shipping))]
        public Guid ReceiverId { get; set; }

        public UserReceiverDto UserReceiver { get; set; } = new UserReceiverDto();

        [Required(ErrorMessageResourceName = "ShippingTypes", ErrorMessageResourceType = typeof(Shipping))]
        public Guid ShippingTypeId { get; set; }
        public Guid? ShipingPackgingId { get; set; }

        [Range(0.1, 1000, ErrorMessageResourceName = "FactorRange", ErrorMessageResourceType = typeof(Shipping))]
        public double Width { get; set; }

        [Range(0.1, 1000, ErrorMessageResourceName = "FactorRange", ErrorMessageResourceType = typeof(Shipping))]
        public double Height { get; set; }

        [Range(0.1, 1000, ErrorMessageResourceName = "FactorRange", ErrorMessageResourceType = typeof(Shipping))]
        public double Weight { get; set; }

        [Range(0.1, 1000, ErrorMessageResourceName = "FactorRange", ErrorMessageResourceType = typeof(Shipping))]
        public double Length { get; set; }

        [Range(1, double.MaxValue, ErrorMessageResourceName = "FactorRequired", ErrorMessageResourceType = typeof(Shipping))]
        public decimal PackageValue { get; set; }

        [Range(0, double.MaxValue, ErrorMessageResourceName = "FactorRange", ErrorMessageResourceType = typeof(Shipping))]
        public decimal ShippingRate { get; set; }
        public Guid? PaymentMethodId { get; set; }

        public Guid? UserSubscriptionId { get; set; }

        public double? TrackingNumber { get; set; }

        public Guid? ReferenceId { get; set; }
        public Guid? CarrierId { get; set; }
    }
}
