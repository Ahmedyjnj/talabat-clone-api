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


    }
}
