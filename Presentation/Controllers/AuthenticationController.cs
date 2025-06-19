using Abstraction;
using Microsoft.AspNetCore.Mvc;
using Shared.Dto_s.IdentityDto_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    
    
   public class AuthenticationController(IServiceManager serviceManager):ApiBaseController
    {
        //login
        [HttpPost("Login")] //as /login  if it in {} in like parameter
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            var user=await serviceManager.AuthenticationServices.LoginAsync(loginDto);

            return Ok(user);
        }

        //register

        [HttpPost("Register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
        {
            var user = await serviceManager.AuthenticationServices.RegisterAsync(registerDto);

            return Ok(user);
        }
    }
}
