using System.Net;
using Api.Exceptions;

namespace Api.Middleware;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (NotFound)
        {
            context.Response.StatusCode = (int)HttpStatusCode.NotFound;
        }
        catch (Exception ex)
        {
            context.Response.StatusCode= (int)HttpStatusCode.BadRequest;
            await context.Response.WriteAsync(ex.Message);
        }
    }
}