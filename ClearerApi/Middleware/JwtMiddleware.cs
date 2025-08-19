using Domain.Interfaces;

namespace ClearerApi.Middleware
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;

        public JwtMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, IJwtService jwtService)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (token != null)
            {
                var userId = jwtService.ValidateToken(token);
                if (userId != null)
                {
                    context.Items["UserId"] = userId;
                }
            }

            await _next(context);
        }

    }
}
