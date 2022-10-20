using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScoreCardManagement.WebApi.Middleware
{
    public class TokenValidationMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly HttpClient _client;
        private readonly Endpoints _endpoints;
        public TokenValidationMiddleware(RequestDelegate next,IOptions<Endpoints> endpoint)
        {
            _next=next;
            _client=new HttpClient();
            _endpoints=endpoint.Value();
            _client.BaseAddress=new Uri(_endpoints.Auth);
        }
        public async Task InvokeAsync(HttpContext httpContext)
        {
         string token = httpContext.Request.Headers["Authorization"];
         if (token == null)
         {
             await Unauthorized(httpContext);
         }

         _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.Split(" ").Last());
          var result = await _client.GetAsync(AuthApi.Validate);

         if (result.IsSuccessStatusCode)
         {
            await _next(httpContext);
         }
         else
         {
             await Unauthorized(httpContext);
         }

        //call auth server to validate token
         
         Task Unauthorized(HttpContext context)
        {
           context.Response.ContentType = "application/json";
           context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;

            return context.Response.WriteAsync(JsonConvert.SerializeObject(new { message = "Unauthorized" }));

        }

    }

    }
}