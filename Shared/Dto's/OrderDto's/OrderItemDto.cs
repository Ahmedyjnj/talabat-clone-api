﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dto_s.OrderDto_s
{
    public class OrderItemDto
    {
        public string ProductName { get; set; } = default!;

        public string PictureUrl { get; set; } = default!;

        public decimal Price { get; set; }

        public int Quantity { get; set; }
    }
}
