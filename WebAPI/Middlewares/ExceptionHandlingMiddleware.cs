using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Threading.Tasks;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;

    public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            // Call the next middleware in the pipeline
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private Task HandleExceptionAsync(HttpContext context, Exception ex)
    {
        // Log the exception
        _logger.LogError(ex, ex.Message);

        // Set the response status code and content type
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

        // Create a response object
        var response = new
        {
            StatusCode = context.Response.StatusCode,
            Message = "An unexpected error occurred.",
            Details = ex.Message // Consider removing this in production for security reasons
        };

        // Write the response
        return context.Response.WriteAsJsonAsync(response);
    }
}
