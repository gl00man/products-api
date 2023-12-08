
using ProductsAPI.Controllers;
using ProductsAPI.Models.Exceptions;

namespace ProductsAPI.Middleware
{
    public class ErrorHandlingMiddleware : IMiddleware
    {
        private readonly ILogger<ErrorHandlingMiddleware> _logger;

        public ErrorHandlingMiddleware(ILogger<ErrorHandlingMiddleware> logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next.Invoke(context);
            }
            catch (NotFoundException ex)
            {
                context.Response.StatusCode = 404;
                await context.Response.WriteAsync("Not Found: " + ex.Message);
                _logger.LogError("Not Found: " + ex.Message);
            }
            catch (IncorrectDataException ex)
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync("Incorrect Data: " + ex.Message);
                _logger.LogError("Incorrect Data: " + ex.Message);
            }
            catch (Exception ex) 
            {
                context.Response.StatusCode = 500;
                await context.Response.WriteAsync("Something went wrong: " + ex.Message);
                _logger.LogError("Something went wrong: " + ex.Message);
            }
        }
    }

}
