using Microsoft.AspNetCore.Mvc;

namespace TPSPoznanici.Middlewares
{
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
                await _next(context);
            }
            catch (Exception exception)
            {
               await HandleExceptionAsync(context, exception);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            _logger.LogError(exception, "Exception occurred: {Message}", exception.Message);

            var problemDetails = new ProblemDetails();

            switch (exception)
            {
                case NotImplementedException:
                    problemDetails.Status = StatusCodes.Status400BadRequest;
                    problemDetails.Title = "Not implemented error.";
                    break;
                case BadHttpRequestException:
                    problemDetails.Status = StatusCodes.Status400BadRequest;
                    problemDetails.Title = "Bad request error.";
                    break;
                case FormatException:
                    problemDetails.Status = StatusCodes.Status400BadRequest;
                    problemDetails.Title = "Format error.";
                    break;
                case InvalidOperationException:
                    problemDetails.Status = StatusCodes.Status404NotFound;
                    problemDetails.Title = "Not found error.";
                    break;
                case KeyNotFoundException:
                    problemDetails.Status = StatusCodes.Status404NotFound;
                    problemDetails.Title = "Not found error.";
                    problemDetails.Detail = exception.Message;
                    break;
                default:
                    problemDetails.Status = StatusCodes.Status500InternalServerError;
                    problemDetails.Title = "Server Error";
                    break;
            }

            context.Response.StatusCode = (int)problemDetails.Status;

            return context.Response.WriteAsJsonAsync(problemDetails);
        }
    }
}
