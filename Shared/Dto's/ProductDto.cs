﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dto_s
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;

        public string PictureUrl { get; set; } = null!;

        public decimal Price { get; set; }


       
        public string BrandName { get; set; }

        public string TypeName { get; set; } 


    }
}
