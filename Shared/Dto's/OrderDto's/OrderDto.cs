using Shared.Dto_s.IdentityDto_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dto_s.OrderDto_s
{
    public class OrderDto
    {
        public string BasketId { get; set; }

        public AddressDto ShipToAddress { get; set; } 

        public int DeliveryMethodId { get; set; }
    }
}
