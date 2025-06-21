using AutoMapper;
using Domain.Models.Orders;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Shared.Dto_s.IdentityDto_s;
using Shared.Dto_s.OrderDto_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.MappingProfiles
{
    public class OrderProfile :Profile
    {
        public OrderProfile()
        {
            CreateMap<AddressDto,OrderAddress>().ReverseMap();

            CreateMap<Order, OrderToReturnDto>()
                .ForMember(dest=>dest.DeliveryMethod,opt=>opt.MapFrom(src=>src.DeliveryMethod.ShortName));


            CreateMap<OrderItem, OrderItemDto>()
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.product.ProductName))
                .ForMember(dest => dest.PictureUrl, opt => opt.MapFrom<OrderItemPictureUrlResolver>());

            CreateMap<DeliveryMethod, DeliveryMethodDto>();


        }

    }
}
