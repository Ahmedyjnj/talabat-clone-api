using Abstraction;
using AutoMapper;
using Domain.Contracts;
using Domain.Exceptions;
using Domain.Models.Orders;
using Domain.Models.Products;
using Services.Specifications;
using Shared.Dto_s.IdentityDto_s;
using Shared.Dto_s.OrderDto_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class OrderServices(IMapper mapper,IBasketRepository basketRepository ,IUnitOfWork unitOfWork) : IOrderServices
    {
        public async Task<OrderToReturnDto> CreateOrder(OrderDto orderDto, string Email)
        {
            var orderAddress =mapper.Map<AddressDto, OrderAddress>(orderDto.ShipToAddress);

            var basket = await basketRepository.GetBasketAsync(orderDto.BasketId)
            ?? throw new BasketNotFoundException(orderDto.BasketId);

            //we need to search what about items from product not basket 
            //from origin source because maybe change happen 

            List<OrderItem> orderItems = [];

            var productRepo =  unitOfWork.GetRepository<Product,int>();

            foreach (var Item in basket.Items)
            {
                var product = await productRepo.GetByIdAsync(Item.Id)
                    ?? throw new ProductNotFoundException(Item.Id);


                orderItems.Add(new OrderItem
                {
                   
                    Price = product.Price,
                    Quantity = Item.Quantity,
                    product=new ProductItemOrdered()
                    {
                        Id = product.Id,
                        ProductName = product.Name,
                        PicturalUrl= product.PictureUrl
                    }
                });

            }


            var DeliveryMethod = await unitOfWork.GetRepository<DeliveryMethod, int>()
                .GetByIdAsync(orderDto.DeliveryMethodId)
                ?? throw new DeliveryMethodNotFoundException(orderDto.DeliveryMethodId);


            var SubTotal = orderItems.Sum(x => x.Price * x.Quantity);


            //orderdto intern to order in model in db then to ordertoreturnDto

            var order = new Order(Email, SubTotal, orderItems, orderAddress, DeliveryMethod);

            unitOfWork.GetRepository<Order, Guid>().Add(order);

            await unitOfWork.SaveChangesAsync();

            return mapper.Map<Order, OrderToReturnDto>(order);




        }

        public async Task<IEnumerable<DeliveryMethodDto>> GetDeliveryMethodsAsync()
        {
           var DeliveryMethods =await unitOfWork.GetRepository<DeliveryMethod, int>()
                .GetAllAsync();

            return mapper.Map<IEnumerable<DeliveryMethod>, IEnumerable<DeliveryMethodDto>>(DeliveryMethods);
        }

        public async Task<OrderToReturnDto> GetOrderByIdAsync(Guid id)
        {
         var spec = new OrderSpecification(id);
            var order = await unitOfWork.GetRepository<Order, Guid>()
                .GetByIdAsync(spec);

            if (order == null)
            {
                throw new OrderNotFoundException(id);
            }
            return mapper.Map<Order, OrderToReturnDto>(order);
               
        }

        public async Task<IEnumerable<OrderToReturnDto>> GetOrdersForUserAsync(string Email)
        {
            var spec = new OrderSpecification(Email);

            var orders =await unitOfWork.GetRepository<Order, Guid>()
                .GetAllAsync(spec);

            return mapper.Map<IEnumerable<Order>, IEnumerable<OrderToReturnDto>>(orders);

        }
    }
}
