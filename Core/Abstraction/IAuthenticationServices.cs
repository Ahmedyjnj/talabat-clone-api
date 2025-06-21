using Shared.Dto_s.IdentityDto_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraction
{
    public interface IAuthenticationServices
    {
        //login
        //take email, password || return token , email , displayname

        Task<UserDto> LoginAsync(LoginDto loginDto);

        //Register
        //take username ,phone email, password, displayname || return token , email , displayname

        Task<UserDto> RegisterAsync(RegisterDto registerDto);

        //check email 
        //take string email || return true or false
        Task<bool> CheckEmailAsync(string email);


        //Get current user Adress
        // take string email || return UserDto Adress dto
        Task<AddressDto> GetCurrentUserAddressAsync(string email);

        //update aadress of current user
        //take AddressDto ,email and return updated adress 
        Task<AddressDto> UpdateCurrentUserAddressAsync(string Email,AddressDto addressDto);

        //get current address
        //take string email return userdto
        Task<UserDto> GetCurrentUserAsync(string email);
    }
}
