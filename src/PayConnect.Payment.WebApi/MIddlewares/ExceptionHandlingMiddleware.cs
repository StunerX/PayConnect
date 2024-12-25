using System.Net;
using Newtonsoft.Json;
using PayConnect.Domain.Exceptions;
using PayConnect.Payment.WebApi.Shared;

namespace PayConnect.Payment.WebApi.MIddlewares;

public class ExceptionHandlingMiddleware(RequestDelegate next)
{
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";

        context.Response.StatusCode = exception switch
        {
            DomainException => (int)HttpStatusCode.BadRequest,
            KeyNotFoundException => (int)HttpStatusCode.NotFound,
            _ => (int)HttpStatusCode.InternalServerError
        };

        var response = new ApiResponse<string>(exception.Message);
        
        return Results.Json(response).ExecuteAsync(context);
    }
}