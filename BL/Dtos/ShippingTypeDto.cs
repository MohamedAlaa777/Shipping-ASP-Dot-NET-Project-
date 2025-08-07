using AppResource;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Dtos.Base;

namespace BL.Dtos
{
    public partial class ShippingTypeDto : BaseDto
    {
        [Required(ErrorMessageResourceName = "NameArRequired", ErrorMessageResourceType = typeof(Messages),AllowEmptyStrings = false )]
        [StringLength(100,MinimumLength = 5, ErrorMessageResourceName = "NameLength", ErrorMessageResourceType =typeof(Messages))]
        public string? ShippingTypeAname { get; set; }
        [Required(ErrorMessageResourceName = "NameEnRequired", ErrorMessageResourceType = typeof(Messages), AllowEmptyStrings = false)]
        [StringLength(100, MinimumLength = 5, ErrorMessageResourceName = "NameLength", ErrorMessageResourceType = typeof(Messages))]
        public string? ShippingTypeEname { get; set; }
        [Required(ErrorMessageResourceName = "FactorRequired", ErrorMessageResourceType = typeof(Shipping), AllowEmptyStrings = false)]
        [Range(0.25,10,ErrorMessageResourceName = "FactorRange", ErrorMessageResourceType =typeof(Shipping))]
        public float ShippingFactor { get; set; }
    }
}
