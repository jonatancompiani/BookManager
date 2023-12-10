namespace Company.BookManager.API.Middlewares;

using System;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Company.BookManager.Domain.DTO;

public class ErrorHandlingMiddleware : IMiddleware
{
    async Task IMiddleware.InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            await this.HandleException(context, ex);
        }
    }

    private Task HandleException(HttpContext context, Exception ex)
    {
        context.Response.StatusCode = StatusCodes.Status500InternalServerError;

        return ex switch
        {
            NotImplementedException => this.HandleNotImplemented(context),
            InvalidDataException id => this.HandleInvalidData(context, id),
            _ => HandleUnexpectedError(context, ex)
        };
    }

    private Task HandleNotImplemented(HttpContext context)
    {
        ApplicationErrorResponse error = new(StatusCodes.Status500InternalServerError, "Not Implemented yet, please come back later!", null);

        var serialized = JsonSerializer.Serialize(error);

        return context.Response.WriteAsync(serialized);
    }

    private Task HandleInvalidData(HttpContext context, InvalidDataException e)
    {
        throw new NotImplementedException();
    }

    private static Task HandleUnexpectedError(HttpContext context, Exception ex)
    {
        ApplicationErrorResponse error = new(StatusCodes.Status500InternalServerError, "Unexpected Error!", ex.Message);

        var serialized = JsonSerializer.Serialize(error);

        return context.Response.WriteAsync(serialized);
    }
}