using AutoMapper;
using Domain.Models.Identity;
using Shared.Dto_s.IdentityDto_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.MappingProfiles
{
    public class IdentityProfile :Profile
    {
        public IdentityProfile()
        {
            CreateMap<Address,AddressDto>().ReverseMap();
        }
    }
}
