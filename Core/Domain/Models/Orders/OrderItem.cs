﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Orders
{
    public class OrderItem:ModelBase<int>
    {
        public ProductItemOrdered product { get; set; } = default!;

        public decimal Price { get; set; }

        public int Quantity { get; set; }
    }
}
