using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dto_s.IdentityDto_s
{
    public class RegisterDto
    {
        [EmailAddress]
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;



        public string UserName { get; set; } = null!;

        public string DisplayName { get; set; } = null!;

        public string PhoneNumber { get; set; } = null!;

        public string Role { get; set; } = null!;
    }
}
