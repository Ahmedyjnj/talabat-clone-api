using Shared.Dto_s.OrderDto_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraction
{
    public interface IOrderServices
    {
        Task<OrderToReturnDto> CreateOrder(OrderDto orderDto,string Email);
    

        Task<IEnumerable<DeliveryMethodDto>> GetDeliveryMethodsAsync();

        Task<OrderToReturnDto> GetOrderByIdAsync(Guid id);

        Task<IEnumerable<OrderToReturnDto>> GetOrdersForUserAsync(string Email);

    }
}
