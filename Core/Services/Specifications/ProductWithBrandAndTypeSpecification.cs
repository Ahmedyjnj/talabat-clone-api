using Domain.Models.Products;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Specifications
{
    public class ProductWithBrandAndTypeSpecification : BaseSpecification<Product,int>
    {
        //we will use swith to handle enum options
        public ProductWithBrandAndTypeSpecification(ProductQueryParams productQuery) :
            base(p=>(!productQuery.BrandId.HasValue || p.BrandId== productQuery.BrandId)
            &&  (!productQuery.TypeId.HasValue || p.TypeId == productQuery.TypeId)
            && (string.IsNullOrEmpty(productQuery.SearchValue) || p.Name.ToLower().Contains(productQuery.SearchValue.ToLower())))
        {
            //for get all  without a send a criteria 

            AddInclude(x => x.Brand);
            AddInclude(x => x.Type);

            switch(productQuery.SortingOption)
            {
                case ProductSortingOptions.NameAsc:
                    AddOrderBy(p => p.Name);
                    break;
                case ProductSortingOptions.NameDesc:
                    AddOrderByDesc(p => p.Name);
                    break;
                case ProductSortingOptions.PriceAsc:
                    AddOrderBy(p => p.Price);
                    break;
                case ProductSortingOptions.PriceDesc:
                    AddOrderByDesc(p => p.Price);
                    break;

                default:
                    //AddOrderBy(p => p.Name);
                    break;
            }

            
            ApplyPagination(productQuery.PageSize,productQuery.PageIndex);

        }

        //this is will base to criteria in base specification to make a where in inputquery
        public ProductWithBrandAndTypeSpecification(int id) : base(p=>p.Id==id) //the constructor of ctor of basespecification will wait a exp
        {
            AddInclude(x => x.Brand);
            AddInclude(x => x.Type);

        }

        


    }
}
