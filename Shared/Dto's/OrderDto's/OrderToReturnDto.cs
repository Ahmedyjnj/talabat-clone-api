using Shared.Dto_s.IdentityDto_s;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dto_s.OrderDto_s
{
    public class OrderToReturnDto
    {
        public Guid Id { get; set; }

        public string UserEmail { get; set; } = default!;


        public DateTimeOffset OrderDate { get; set; } = DateTimeOffset.Now;


        public AddressDto ShipToAddress { get; set; } = default!;

        public string DeliveryMethod { get; set; } = default!;

        public string OrderStatus { get; set; } = default!;

        public ICollection<OrderItemDto> Items { get; set; } = [];

        public decimal SubTotal { get; set; }

        public decimal Total { get; set; }

    }
}
