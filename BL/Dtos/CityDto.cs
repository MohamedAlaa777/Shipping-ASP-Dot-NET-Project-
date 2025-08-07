using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppResource;
using BL.Dtos.Base;
namespace BL.Dtos
{
    public partial class CityDto : BaseDto
    {
        [Required(ErrorMessageResourceName = "NameArRequired", ErrorMessageResourceType = typeof(Messages), AllowEmptyStrings = false)]
        [StringLength(100, MinimumLength = 3, ErrorMessageResourceName = "NameLength", ErrorMessageResourceType = typeof(Messages))]
        public string? CityAname { get; set; }
        [Required(ErrorMessageResourceName = "NameArRequired", ErrorMessageResourceType = typeof(Messages), AllowEmptyStrings = false)]
        [StringLength(100, MinimumLength = 3, ErrorMessageResourceName = "NameLength", ErrorMessageResourceType = typeof(Messages))]
        public string? CityEname { get; set; }

        public string? CountryAname { get; set; }

        public string? CountryEname { get; set; }

        [Required(ErrorMessageResourceName = "CountryRequired", ErrorMessageResourceType = typeof(Messages), AllowEmptyStrings = false)]
        public Guid CountryId { get; set; }
    }
}
