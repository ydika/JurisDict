using JurisDict.Api.Middlewares;

namespace JurisDict.Api.Extensions
{
    public static class HttpExceptionExtension
    {
        public static IApplicationBuilder UseHttpExceptions(this IApplicationBuilder applicationBuilder)
        {
            return applicationBuilder.UseMiddleware<HttpExceptionMiddleware>();
        }
    }
}
