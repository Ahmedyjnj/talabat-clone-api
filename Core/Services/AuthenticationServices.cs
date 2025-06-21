using Abstraction;
using AutoMapper;
using Domain.Exceptions;
using Domain.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Shared.Dto_s.IdentityDto_s;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class AuthenticationServices(UserManager<ApplicationUser> userManager ,IConfiguration configuration,IMapper mapper) : IAuthenticationServices
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
                    Token=await CreateTokenAsync(user)
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
            var result = await userManager.CreateAsync(user, registerDto.Password);

            var roleResult = await userManager.AddToRoleAsync(user, "SuperAdmin");

            if (!roleResult.Succeeded)
            {
                var errors = roleResult.Errors.Select(e => e.Description).ToList();
                throw new BadRequestException(errors);
            }

            if (result.Succeeded)
            {
                return new UserDto()
                {
                    DisplayName = registerDto.DisplayName,
                    Email = registerDto.Email,
                    Token =await CreateTokenAsync(user)

                };

            }
            else
            {
                var Errors = result.Errors.Select(E=>E.Description).ToList();
                
                throw new BadRequestException(Errors);

            }
        
        
        
        }


        public  async Task<string> CreateTokenAsync(ApplicationUser user)
        {
            var Claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Email,user.Email),
                new Claim(ClaimTypes.NameIdentifier,user.Id),
                new Claim(ClaimTypes.Name,user.UserName),

            };

            var Roles =await userManager.GetRolesAsync(user);

            foreach (var role in Roles)
            {
                Claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var SecretKey = configuration.GetSection("JwtOptions")["SecretKey"];

            var Key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecretKey));

            //we now will make a signing credentials to make token بيانات التوقيع 

            var creds = new SigningCredentials(Key, SecurityAlgorithms.HmacSha256);


            var token = new JwtSecurityToken
             (
               issuer: configuration["JwtOptions:Issuer"],
               audience: configuration["JwtOptions:Audience"],
               claims: Claims,
               expires: DateTime.Now.AddDays(1),
               signingCredentials: creds
            );

            return  new JwtSecurityTokenHandler().WriteToken(token);


            //we wiill make configration in appsettings.json and we will make secret key
            // we will use jwt secret key jenerator
            // and we will make issuser audiance as base url
        }

        public async Task<bool> CheckEmailAsync(string email)
        {
            var user =await userManager.FindByEmailAsync(email);
            return user is not null;
        }

        public async Task<AddressDto> GetCurrentUserAddressAsync(string email)
        {
            var user = await userManager.Users.Include(u=>u.Address).FirstOrDefaultAsync(u=>u.Email==email)
                ??throw new UserNotFoundException(email);

            if (user.Address is not null)
            {
               return mapper.Map<Address,AddressDto>(user.Address);
            }
            else
            {
                throw new AddressNotFoundException(user.UserName);
            }

        }

        public async Task<AddressDto> UpdateCurrentUserAddressAsync(string Email,AddressDto addressDto)
        {

            var user = await userManager.Users.Include(u => u.Address).FirstOrDefaultAsync(u => u.Email == Email)
                ?? throw new UserNotFoundException(Email);

            if(user.Address is not null)
            {
                user.Address.Street = addressDto.Street;
                user.Address.City = addressDto.City;
                user.Address.Country = addressDto.Country;
                user.Address.FirstName = addressDto.FirstName;
                user.Address.LastName = addressDto.LastName;
               
            }
            else
            {
               user.Address = mapper.Map<AddressDto, Address>(addressDto);
            }
            await userManager.UpdateAsync(user);

            return mapper.Map<Address, AddressDto>(user.Address);

        }

        public async Task<UserDto> GetCurrentUserAsync(string email)
        {
            var user =await userManager.FindByEmailAsync(email) ?? throw new UserNotFoundException(email);

            return new UserDto()
            {
                DisplayName = user.DisplayName,
                Email = user.Email,
                Token =await CreateTokenAsync(user)

            };
            
        }
    }
}
