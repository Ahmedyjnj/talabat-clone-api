using Abstraction;
using AutoMapper;
using Domain.Contracts;
using Domain.Exceptions;
using Domain.Models.Basket;
using Shared.Dto_s.BasketDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class BasketServices(IBasketRepository basketRepository,IMapper mapper) : IBasketServices
    {
        public async Task<BasketDto> GetBasketAsync(string Key)
        {
            var basket =await basketRepository.GetBasketAsync(Key);

            if (basket is not null)
                return mapper.Map<CustomerBasket, BasketDto>(basket);
            else
            {
                throw new BasketNotFoundException(Key);
            }
        }

        public async Task<BasketDto> CreateOrUpdateBasketAsync(BasketDto basket)
        {
           var customerBasket = mapper.Map<BasketDto, CustomerBasket>(basket);

            var CreateOrUpdateBasket = await basketRepository.CreateOrUpdateBasketAsync(customerBasket);


            if (CreateOrUpdateBasket is not null)
            {
               return await GetBasketAsync(basket.Id);
                
            }
            else
            {
                throw new Exception("Basket could not be created or updated.");
            }

        }

        public Task<bool> DeleteBasketAsync(string Key)
        {
            return basketRepository.DeleteBasketAsync(Key);
        }

   
    }
}
