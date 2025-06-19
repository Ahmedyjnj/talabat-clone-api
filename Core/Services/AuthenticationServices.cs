using Abstraction;
using Domain.Exceptions;
using Domain.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Shared.Dto_s.IdentityDto_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class AuthenticationServices(UserManager<ApplicationUser> userManager) : IAuthenticationServices
    {

        //we now need to use inject user manager to make find from user db
        public async Task<UserDto> LoginAsync(LoginDto loginDto)
        {
            var user =await userManager.FindByEmailAsync(loginDto.Email);
            if(user is null)  throw new UserNotFoundException(loginDto.Email);

            var IsPasswordVaild = await userManager.CheckPasswordAsync(user,loginDto.Password);
        
            if(IsPasswordVaild)
            {
                return new UserDto()
                {
                    DisplayName=user.DisplayName,
                    Email=loginDto.Email,
                    Token= CreateTokenAsync(user)
                };
            }
            else
            {
                throw new UnauthorizedException();

            }
        }

        public async Task<UserDto> RegisterAsync(RegisterDto registerDto)
        {
            var user = new ApplicationUser()
            {
                DisplayName = registerDto.DisplayName,
                Email=registerDto.Email,
                PhoneNumber=registerDto.PhoneNumber,
                UserName = registerDto.UserName,

            };
            var result =await userManager.CreateAsync(user,registerDto.Password);
       
            if(result.Succeeded)
            {
                return new UserDto()
                {
                    DisplayName = registerDto.DisplayName,
                    Email = registerDto.Email,
                    Token = CreateTokenAsync(user)

                };

            }
            else
            {
                var Errors = result.Errors.Select(E=>E.Description).ToList();
                
                throw new BadRequestException(Errors);

            }
        
        
        
        }


        public static string CreateTokenAsync(ApplicationUser user)
        {
            return "To_Do";
        }
    }
}
