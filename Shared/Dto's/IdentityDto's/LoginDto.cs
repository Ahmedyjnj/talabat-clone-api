﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dto_s.IdentityDto_s
{
   public  class LoginDto
    {
        [EmailAddress]
        public string Email { get; set; } =null!;

        public string Password { get; set; } = null!;


        



    }
}
