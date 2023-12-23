using System.Net;

namespace Server_Side.Middlewares
{
    public class LanguageCheckMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<LanguageCheckMiddleware> _logger;

        public LanguageCheckMiddleware(RequestDelegate next , ILogger<LanguageCheckMiddleware> logger )
        {
            _next = next;
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                if (context.Request.Headers.ContainsKey("Accept-Language"))
                {
                    string languageCode = context.Request.Headers["Accept-Language"];
                    context.Items["LanguageCode"]= languageCode;
                }
                await _next(context);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex,ex.Message);
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int) HttpStatusCode.InternalServerError;
            }
        }
    }
}
