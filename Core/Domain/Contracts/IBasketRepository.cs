﻿using Domain.Models.Basket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts
{
    public interface IBasketRepository
    {
        Task<CustomerBasket> GetBasketAsync(string Key);

        Task<CustomerBasket> CreateOrUpdateBasketAsync(CustomerBasket customerBasket, TimeSpan? TimeToLive =null);
   
        Task<bool> DeleteBasketAsync(string Key);

    }
}
