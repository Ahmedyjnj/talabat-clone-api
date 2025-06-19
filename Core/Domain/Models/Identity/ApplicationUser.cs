using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Identity
{
    public class ApplicationUser :IdentityUser
    {
        public string DisplayName { get; set; } = null!;

        public Address? Address { get; set; }

        //we will make context only for identity we need to make business in db 
        //and identity in other table




    }
}
