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
    public partial class CountryDto : BaseDto
    {
        [Required(ErrorMessageResourceName = "NameArRequired", ErrorMessageResourceType = typeof(Messages), AllowEmptyStrings = false)]
        [StringLength(100, MinimumLength = 5, ErrorMessageResourceName = "NameLength", ErrorMessageResourceType = typeof(Messages))]
        public string? CountryAname { get; set; }
        [Required(ErrorMessageResourceName = "NameEnRequired", ErrorMessageResourceType = typeof(Messages), AllowEmptyStrings = false)]
        [StringLength(100, MinimumLength = 5, ErrorMessageResourceName = "NameLength", ErrorMessageResourceType = typeof(Messages))]
        public string? CountryEname { get; set; }
    }
}
