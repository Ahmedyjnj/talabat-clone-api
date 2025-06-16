using Domain.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Specifications
{
    public class ProductWithBrandAndTypeSpecification : BaseSpecification<Product,int>
    {
        public ProductWithBrandAndTypeSpecification() : base(null)
        {
            //for get all  without a send a criteria 

            AddInclude(x => x.Brand);
            AddInclude(x => x.Type);
        }

        //public ProductWithBrandAndTypeSpecification(int id) : base(id)
        //{
            

        //    AddInclude(x => x.Brand);
        //    AddInclude(x => x.Type);
        //}




    }
}
