using Abstraction;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;
using Shared.Dto_s.BasketDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
   
    public class BasketController(IServiceManager serviceManager) : ApiBaseController
    {
        [HttpGet]
        public async Task<ActionResult<BasketDto>> GetBasket(String key)
        {
            var basket = await serviceManager.BasketServices.GetBasketAsync(key);

            return Ok(basket);

        }


        [HttpPost]
        public async Task<ActionResult<BasketDto>> CreateOrUbdateBasket(BasketDto basket)
        {
            var Basket = await serviceManager.BasketServices.CreateOrUpdateBasketAsync(basket);
            return Ok(basket);

        }



        [HttpDelete("{key}")]
        public async Task<ActionResult> DeleteBasket(string key)
        {
           var result = await serviceManager.BasketServices.DeleteBasketAsync(key);
            return Ok(result);


        }
         //as my password on upentu 012369123456
        /**sudo service redis-server status
           sudo service redis-server start
           sudo service redis-server stop **/
    }
}
