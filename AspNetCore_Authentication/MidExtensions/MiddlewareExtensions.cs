using Microsoft.AspNetCore.Builder;
using AspNetCore_Authentication.Middleware;

namespace AspNetCore_Authentication.MidExtensions
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseAuthenticationMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<AuthenticationMiddleware>();
        }
    }
}
