using Domain.Contracts;
using Domain.Models.Basket;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Persistance.Repositories
{
    public class BasketRepository(IConnectionMultiplexer connection) : IBasketRepository
    {
        private readonly IDatabase _database =connection.GetDatabase();

        public async Task<CustomerBasket> GetBasketAsync(string Key)
        {
            var Basket = await _database.StringGetAsync(Key);

            if (Basket.IsNullOrEmpty)
            {
                return null;
            }
            else
            {
                return JsonSerializer.Deserialize<CustomerBasket>(Basket!);
              
            }

        }
        public async Task<CustomerBasket> CreateOrUpdateBasketAsync(CustomerBasket customerBasket, TimeSpan? TimeToLive = null)
        {
            var jsonBasket =JsonSerializer.Serialize(customerBasket);

            var Iscreatedorupdated=await _database.StringSetAsync(customerBasket.Id, jsonBasket, TimeToLive??TimeSpan.FromDays(30));

            if (Iscreatedorupdated)
            {
                return await GetBasketAsync(customerBasket.Id);
            }
            else
            {
                return null;
            }

        }

        public Task<bool> DeleteBasketAsync(string Key)
        {
            return _database.KeyDeleteAsync(Key);
        }

    }
}
