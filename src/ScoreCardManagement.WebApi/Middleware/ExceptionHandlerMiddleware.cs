using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Text.Json;
namespace ScoreCardManagement.WebApi.Middleware
{
    public class ExceptionHandlerMiddleware
 {
    private readonly RequestDelegate _next;

    public ExceptionHandlerMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception error)
        {
            var response = context.Response;
            response.ContentType = "application/json";

            switch(error)
            {
                case Exception e:
                    // custom application error
                    response.StatusCode = (int)HttpStatusCode.InternalServerError;
                  //  response.StatusCode = (int)HttpStatusCode.BadRequest;
                    break;
                
                default:
                    // unhandled error
                    
                    break;
            }

            var result = JsonSerializer.Serialize(new { message = error?.Message });
            await response.WriteAsync(result);
        }
    }
 }

 
}








