using AspNetCore_Authentication.Services;
using Microsoft.AspNetCore.Http.HttpResults;

namespace AspNetCore_Authentication.Middleware
{
    public class AuthenticationMiddleware
    {
        RequestDelegate _next;
        IJwtAuthenticationService _jwtAuthenticationService;
        public AuthenticationMiddleware(RequestDelegate next,IJwtAuthenticationService jwtAuthenticationService)
        {
            _next = next;
            _jwtAuthenticationService = jwtAuthenticationService;
        }

        public async Task Invoke(HttpContext context) 
        {
            if(context.Request.Path.ToString().Contains ("Login"))
            {
              await  _next(context);
                return;
            }
            var authizationToken = context.Request.Headers["Authorization"].ToString();
            if (!string.IsNullOrEmpty(authizationToken))
            {

                string status = _jwtAuthenticationService.ValidateToken(authizationToken);
                if (status == "Valid")
                {
                    context.Response.Headers["MyTokenisValidOrnot"] = status;
                    await _next(context); //respetive action
                }
                else
                {
                    context.Response.Headers["MyTokenisValidOrnot"] = status;
                    return;
                }
            }
            else
            {
                context.Response.Headers["MyTokenisValidOrnot"] = "Plese give your token";
                return;

            }
        }
    }
}
