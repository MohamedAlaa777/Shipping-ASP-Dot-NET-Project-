using AppResource;
using BL.Dtos.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Dtos
{
    public class UserDto : BaseDto
    {
        [Required(ErrorMessageResourceType = typeof(Shipping), ErrorMessageResourceName = "EmailRequired")]
        [EmailAddress(ErrorMessageResourceType = typeof(Shipping), ErrorMessageResourceName = "InvalidEmail")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessageResourceType = typeof(Shipping), ErrorMessageResourceName = "PasswordRequired")]
        [MinLength(6, ErrorMessageResourceType = typeof(Shipping), ErrorMessageResourceName = "PasswordMinLength")]
        public string Password { get; set; } = null!;

        [Required(ErrorMessageResourceType = typeof(Shipping), ErrorMessageResourceName = "ConfirmPasswordRequired")]
        [Compare("Password", ErrorMessageResourceType = typeof(Shipping), ErrorMessageResourceName = "PasswordMismatch")]
        public string? ConfirmPassword { get; set; }

        [Required(ErrorMessageResourceType = typeof(Shipping), ErrorMessageResourceName = "FirstNameRequired")]
        [StringLength(50, ErrorMessageResourceType = typeof(Shipping), ErrorMessageResourceName = "FirstNameMaxLength")]
        public string FirstName { get; set; } = null!;

        [Required(ErrorMessageResourceType = typeof(Shipping), ErrorMessageResourceName = "LastNameRequired")]
        [StringLength(50, ErrorMessageResourceType = typeof(Shipping), ErrorMessageResourceName = "LastNameMaxLength")]
        public string LastName { get; set; } = null!;

        [Required(ErrorMessageResourceType = typeof(Shipping), ErrorMessageResourceName = "PhoneRequired")]
        [Phone(ErrorMessageResourceType = typeof(Shipping), ErrorMessageResourceName = "InvalidPhone")]
        public string Phone { get; set; } = null!;

        public string? Role { get; set; }

        public string? ReturnUrl { get; set; }
    }
}
