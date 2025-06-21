using Abstraction;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Shared.Dto_s.IdentityDto_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controllers
{


    public class AuthenticationController(IServiceManager serviceManager) : ApiBaseController
    {
        //login
        [HttpPost("Login")] //as /login  if it in {} in like parameter
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            var user = await serviceManager.AuthenticationServices.LoginAsync(loginDto);

            return Ok(user);
        }

        //register

        [HttpPost("Register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
        {
            var user = await serviceManager.AuthenticationServices.RegisterAsync(registerDto);

            return Ok(user);
        }


        [HttpGet("CheckEmail")]
        public async Task<ActionResult<bool>> CheckEmail(string email)
        {
            var isExist = await serviceManager.AuthenticationServices.CheckEmailAsync(email);
            return Ok(isExist);
        }


        [HttpGet("GetCurrentUser")]
        public async Task<ActionResult<UserDto>> GetCurrentUser()
        {
            //or we can use the email of user that make token that login
            var email = User.FindFirstValue(ClaimTypes.Email);
            var user =await serviceManager.AuthenticationServices.GetCurrentUserAsync(email);
            return Ok(user);
        }





        [HttpGet("Address")]

        public async Task<ActionResult<AddressDto>> GetCurrentUserAddress()
        {
            //or we can use the email of user that make token that login
            var email = User.FindFirstValue(ClaimTypes.Email);
            var address = await serviceManager.AuthenticationServices.GetCurrentUserAddressAsync(email);
            return Ok(address);
        }



        [HttpPost("Address")]
        public async Task<ActionResult<AddressDto>> UpdateCurrentUserAddress(AddressDto addressDto)
        {
            //or we can use the email of user that make token that login
            var email = User.FindFirstValue(ClaimTypes.Email);
            var address = await serviceManager.AuthenticationServices.UpdateCurrentUserAddressAsync(email, addressDto);
            return Ok(address);




        }
    }
}
