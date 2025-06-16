using Abstraction;
using AutoMapper;
using Domain.Contracts;
using Domain.Models.Products;
using Services.Specifications;
using Shared.Dto_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ProductServices(IUnitOfWork unitOfWork ,IMapper mapper) : IProductServices
    {
        public async Task<IEnumerable<BrandDto>> GetAllBrandsAsync()
        {
            var _Repository = unitOfWork.GetRepository<ProductBrand, int>();

            var Brands=await _Repository.GetAllAsync();

            // we need to map the data from entity to dto

            // we can use automapper or manual mapping
            // we will use automapper

            var mappedBrands = mapper.Map<IEnumerable<ProductBrand>, IEnumerable<BrandDto>>(Brands);

            return mappedBrands;


        }





        public async Task<IEnumerable<ProductDto>> GetAllProductsAsync()
        {
            var _Repository = unitOfWork.GetRepository<Product, int>();

            var spec = new ProductWithBrandAndTypeSpecification();//2 includes  without criteria

            var Products = await _Repository.GetAllAsync(spec );

            var mappedProducts = mapper.Map<IEnumerable<Product>, IEnumerable<ProductDto>>(Products);






            return mappedProducts;
        }
















        public async Task<IEnumerable<TypeDto>> GetAllTypesAsync()
        {
            var _Repository = unitOfWork.GetRepository<ProductType, int>();

            var Types = await _Repository.GetAllAsync();

           
            var mappedTypes = mapper.Map<IEnumerable<ProductType>, IEnumerable<TypeDto>>(Types);

            return mappedTypes;
        }

        public async Task<ProductDto> GetProductByIdAsync(int id)
        {
            var product = await unitOfWork.GetRepository<Product, int>().GetByIdAsync(id);

            return mapper.Map<Product,ProductDto>(product);
        }
    }
}
