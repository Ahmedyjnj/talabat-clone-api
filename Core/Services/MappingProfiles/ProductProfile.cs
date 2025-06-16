using AutoMapper;
using Domain.Models.Products;
using Shared.Dto_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.MappingProfiles
{
    public class ProductProfile:Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDto>()
                .ForMember(Dist => Dist.BrandName, options => options.MapFrom(src => src.Brand.Name))
                .ForMember(Dist => Dist.TypeName, options => options.MapFrom(src => src.Type.Name))
                .ForMember(Dist => Dist.PictureUrl,options=>options.MapFrom<ProductResolver>());
            //this is old but gold we need to add reference to that base url to change easy in external




            CreateMap<ProductBrand, BrandDto>();
            CreateMap<ProductType, TypeDto>();




        }
    }
}
