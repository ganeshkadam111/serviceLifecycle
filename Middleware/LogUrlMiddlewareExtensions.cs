namespace ServiceLifecycle.Middleware
{
    public static class LogUrlMiddlewareExtensions
    {
        /// <summary>
        /// added custom middleware in application builder collection
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseLogUrl(this IApplicationBuilder app)
        {
            return app.UseMiddleware<LogUrlMiddleware>();
        }
    }
}
