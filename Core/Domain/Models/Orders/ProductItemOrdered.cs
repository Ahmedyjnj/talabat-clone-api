﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Orders
{
    public class ProductItemOrdered
    {
        public int Id { get; set; }

        public string ProductName { get; set; } = default!;
      


        public string PicturalUrl { get; set; } = default!;
    }
}
