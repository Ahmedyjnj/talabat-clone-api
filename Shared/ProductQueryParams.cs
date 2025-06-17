using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    //int? brandId,int? TypeId,ProductSortingOptions SortingOption)

    public class ProductQueryParams
    {

        private const int DefaultPageSize = 5;
        private const int MaximumPageSize = 10;



        public int? BrandId { get; set; } //nullable int

        public int? TypeId { get; set; } //nullable int

        public ProductSortingOptions SortingOption { get; set; } 

        public string? SearchValue { get; set; } 


        public int PageIndex { get; set; }

        public int pageSize =DefaultPageSize;

        public int PageSize
        {
            get { return pageSize; }
            set
            {
              pageSize= value>MaximumPageSize ? MaximumPageSize :value; 
            }

        }


     
    }
}
