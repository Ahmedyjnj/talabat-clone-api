using Azure;
using Domain.Exceptions;
using Microsoft.Extensions.Logging;
using Shared.ErrorModels;
using System.Text.Json;

namespace E_Commerece.wep.CustomMiddlewares
{
    public class CustomExceptionMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger<CustomExceptionMiddleware> logger;

        public CustomExceptionMiddleware(RequestDelegate Next ,ILogger<CustomExceptionMiddleware> logger)
        {
            next = Next;
            this.logger = logger;
        }

        public async Task Invoke(HttpContext httpContext)
        {

            try
            {

                await next.Invoke(httpContext);

                // this will invoke the next middleware in the pipeline
                if (httpContext.Response.StatusCode==StatusCodes.Status404NotFound)
                {
                    var response = new ErrorToReturn
                    {
                        StatusCode = httpContext.Response.StatusCode,
                        ErrorMessage = $" End Point {httpContext.Request.Path} is not found"
                    };
                    httpContext.Response.ContentType = "application/json";

                    var ResponseToReturn = JsonSerializer.Serialize(response);

                    await httpContext.Response.WriteAsync(ResponseToReturn);
                }


            }
            catch (Exception ex)
            {
                logger.LogError(ex, "something wrong"); //error models

                var response = new ErrorToReturn
                {
                   
                    ErrorMessage = ex.Message
                   
                };


                response.StatusCode =ex switch
                {
                    NotFoundException => StatusCodes.Status404NotFound,
                    UnauthorizedException=>StatusCodes.Status401Unauthorized,
                    BadRequestException badRequestException => GetBadRequestErrors(badRequestException,response),
                    _ => StatusCodes.Status500InternalServerError
                };
                httpContext.Response.ContentType = "application/json";
                // we should make type first then make a  response messsage 

                //response object as json 

               


                var ResponseToReturn = JsonSerializer.Serialize(response);
                //this will return the response as json


                await httpContext.Response.WriteAsync(ResponseToReturn);







            }


        }

        private static int GetBadRequestErrors(BadRequestException badRequestException,ErrorToReturn response)
        {
            response.Errors = badRequestException.Errors;
            return StatusCodes.Status400BadRequest;
        }

        // this as normal will only handle a internal server error 
        //but other errors like not found product is exceptions of model in controller 
        //so to handle these exception we will make class to in domain 


        // in not found end point he dont have place to handle exception in it so he will make if in response of invoke
    
    // in validation errors there are more than error list of errors response
    //as status code message and list of  errors validationerrors each groub has fueld and error
    
    // because this error in controller we will make class in dto 
    
    
    }
}
