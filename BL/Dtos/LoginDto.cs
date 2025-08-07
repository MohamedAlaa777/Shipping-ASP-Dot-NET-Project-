using AppResource;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Dtos
{
    public class LoginDto
    {
        [Required(ErrorMessageResourceType = typeof(Shipping), ErrorMessageResourceName = "EmailRequired")]
        [EmailAddress(ErrorMessageResourceType = typeof(Shipping), ErrorMessageResourceName = "InvalidEmail")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessageResourceType = typeof(Shipping), ErrorMessageResourceName = "PasswordRequired")]
        [MinLength(6, ErrorMessageResourceType = typeof(Shipping), ErrorMessageResourceName = "PasswordMinLength")]
        public string Password { get; set; } = null!;
    }
}
