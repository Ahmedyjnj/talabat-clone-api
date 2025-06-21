using Abstraction;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Dto_s.OrderDto_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    public class OrderController(IServiceManager serviceManager) : ApiBaseController
    {

        [Authorize]
        [HttpPost]

        public async Task<ActionResult<OrderToReturnDto>> CreateOrder(OrderDto orderDto)
        {
            var Email = User.FindFirstValue(ClaimTypes.Email);

            var order = await serviceManager.orderServices.CreateOrder(orderDto, Email);
            return Ok(order);
        }

        [HttpGet("DeliveryMethods")]

        public async Task<ActionResult<IEnumerable<DeliveryMethodDto>>> GetDeliveryMethods()
        {
            var deliveryMethods = await serviceManager.orderServices.GetDeliveryMethodsAsync();
            return Ok(deliveryMethods);
        }


        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderToReturnDto>>> GetOrdersForUser()
        {
            var Email = User.FindFirstValue(ClaimTypes.Email);
            var orders = await serviceManager.orderServices.GetOrdersForUserAsync(Email);
            return Ok(orders);
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderToReturnDto>> GetOrderById(Guid id)
        {
            var order = await serviceManager.orderServices.GetOrderByIdAsync(id);

            return Ok(order);

        }
    }
}
