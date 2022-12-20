namespace ServiceLifecycle.Middleware
{
    public class LogUrlMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<LogUrlMiddleware> _logger;

        public LogUrlMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            _next = next;
            _logger = loggerFactory?.CreateLogger<LogUrlMiddleware>()??  throw new ArgumentNullException(nameof(loggerFactory));
        }

        /// <summary>
        /// Custom middleware logs  Request URl information here
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task InvokeAsync(HttpContext context)
        {
            _logger.LogInformation($"Request URl: {Microsoft.AspNetCore.Http.Extensions.UriHelper.GetDisplayUrl(context.Request)}");
            await this._next(context);
        }
    }
}
