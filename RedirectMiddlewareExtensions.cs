namespace Redirector;

static class RedirectMiddlewareExtensions
{
    public static IApplicationBuilder UseRedirector(this IApplicationBuilder builder) =>
        builder.UseMiddleware<RedirectorMiddleware>();
}