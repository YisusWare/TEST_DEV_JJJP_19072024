using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TEST_DEV_API.ValidationAttributes;

namespace TEST_DEV_API.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [CustomEmail]
        public string Email { get; set; }
        [Required]
        [StringLength(8, MinimumLength = 4)]
        public string Password { get; set; }
    }
}
