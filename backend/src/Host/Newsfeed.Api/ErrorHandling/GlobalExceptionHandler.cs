using Microsoft.AspNetCore.Diagnostics;
using Newsfeed.Application.Exceptions;
using Newsfeed.Application.Wrappers;
using Newsfeed.Domain.Exceptions;
using System.Net;

namespace Newsfeed.Api.ErrorHandling;

public class GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger) : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        logger.LogError(exception, "Exception occurred: {Message}", exception.Message);

        var response = httpContext.Response;

        response.StatusCode = exception switch
        {
            ApiException => (int)HttpStatusCode.BadRequest,
            ValidationException => (int)HttpStatusCode.BadRequest,
            NewsfeedDomainException => (int)HttpStatusCode.BadRequest,
            _ => (int)HttpStatusCode.InternalServerError,
        };

        var serviceResponse = new ServiceResponse<string>(string.Empty, "Có lỗi trong quá trình xử lý!", false, response.StatusCode)
        {
            SystemMessage = exception.Message
        };


        await response.WriteAsJsonAsync(serviceResponse, cancellationToken: cancellationToken);

        return true;
    }
}
