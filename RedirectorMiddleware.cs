using Microsoft.Extensions.Options;

namespace Redirector;

class RedirectorMiddleware
{
    const int permanentRedirect = 301;
    const int temporaryRedirect = 302;

    readonly RequestDelegate next;

    public RedirectorMiddleware(RequestDelegate next) => this.next = next;

    public Task InvokeAsync(HttpContext context, IOptionsSnapshot<RedirectOptions> options)
    {
        if (options.Value.BaseUrl is null)
            return next(context);
        var redirectUrl = new UriBuilder(options.Value.BaseUrl)
        {
            Path = context.Request.Path
        };
        context.Response.Headers.Location = redirectUrl.ToString();
        context.Response.StatusCode = options.Value.IsPermanent ? permanentRedirect : temporaryRedirect;
        return Task.CompletedTask;
    }
}