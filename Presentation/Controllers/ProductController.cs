using Abstraction;
using Microsoft.AspNetCore.Mvc;
using Shared;
using Shared.Dto_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    //we need to add reference to frramework aspnetcore.app
    //then rebuild

    //we need to specify type so we will work with actionresult

    [ApiController]
    [Route("api/[controller]")]
    public class ProductController(IServiceManager serviceManager) : ControllerBase
    {


        //but we have a problem that a in pass of string we easy to make enum rather than string


        [HttpGet]  // we will pass parameters in get that is type of query string pass
        public async Task<ActionResult<PaginatedResult<ProductDto>>> GetAllProducts([FromQuery]ProductQueryParams productQuery)
        {
            var products = await serviceManager.ProductServices.GetAllProductsAsync(productQuery);

            return Ok(products);//status 200


        }


        [HttpGet("brands")]
        //this segment to prevent conflict of two get methods
        //api/product/brands
        public async Task<ActionResult<IEnumerable<BrandDto>>> GetAllBrands()
        {
            var brands = await serviceManager.ProductServices.GetAllBrandsAsync();

            return Ok(brands);//status 200
        }




        [HttpGet("Types")]
       
        public async Task<ActionResult<IEnumerable<TypeDto>>> GetAllTypes()
        {
            var types = await serviceManager.ProductServices.GetAllTypesAsync();

            return Ok(types);//status 200
        }







        [HttpGet("{id}")] //we should write a {} to make a connect

        public async Task<ActionResult<ProductDto>> GetProductById(int id)
        {
            var product = await serviceManager.ProductServices.GetProductByIdAsync(id);

            return Ok(product);//status 200
        }


        




    }
}
