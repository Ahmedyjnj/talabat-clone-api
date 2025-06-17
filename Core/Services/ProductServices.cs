using Abstraction;
using AutoMapper;
using Domain.Contracts;
using Domain.Models.Products;
using Services.Specifications;
using Shared;
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





        public async Task<PaginatedResult<ProductDto>> GetAllProductsAsync(ProductQueryParams productQuery)
        {

            //we need now to make this where => p=>p.brandid==Brandid && p.typeid==TypeId
            //we need to add this expresiion of func in spex

            var _Repository = unitOfWork.GetRepository<Product, int>();

            var spec = new ProductWithBrandAndTypeSpecification(productQuery);//2 includes  without criteria

            var Products = await _Repository.GetAllAsync(spec );

            var mappedProducts = mapper.Map<IEnumerable<Product>, IEnumerable<ProductDto>>(Products);

            var CountedProducts = Products.Count();


            //we will make a small specification to get count

            var CountSpec = new ProductCountSpecification(productQuery);
            var TotalCount = await _Repository.CountAsync(CountSpec); //we will make method of count in generic repo not service

             //we will return object of pagination result
            return new PaginatedResult<ProductDto>
            (
                productQuery.PageIndex,
                CountedProducts,
                TotalCount,
                mappedProducts

            );
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
            var Spec = new ProductWithBrandAndTypeSpecification(id);

            
            var product = await unitOfWork.GetRepository<Product, int>().GetByIdAsync(Spec);

            return mapper.Map<Product,ProductDto>(product);
        }
    }
}
