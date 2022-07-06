using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Threading.Tasks;

namespace AngularTest.Middleware
{
    public class TestMiddleware
    {
        private readonly RequestDelegate _next;

        public TestMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext, ILogger<TestMiddleware> logger)
        {
            logger.LogInformation($"{httpContext.Request.Path}");

            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                if (ex is NullReferenceException nullReferenceException && nullReferenceException.Message == "No data available")
                {
                    httpContext.Response.StatusCode = (int)HttpStatusCode.NoContent;
                    httpContext.Response.ContentType = "application/json";
                    await httpContext.Response.WriteAsync("No data available");
                }
            }
        }
    }
}
