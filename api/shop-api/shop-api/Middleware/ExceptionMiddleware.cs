using shop_api.Errors;
using System.Net;
using System.Text.Json;

namespace shop_api.Middleware;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionMiddleware> _logger;
    private readonly IHostEnvironment _env;

    public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger, IHostEnvironment env)
    {
        _next = next;
        _logger = logger;
        _env = env;
    }

    // will be executed when the middleware acitvate
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            // it calls the middleware in the pipeline
            await _next(context);
        }
        catch (Exception ex) 
        {
            _logger.LogError(ex.Message); // log the exception to be cleared for us
            context.Response.ContentType = "application/json"; // the content response will be of the type json 
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError; // set the status code to be 500 error, internal server

            // its an error object creation based on the environment ( developer or production )
            var response = _env.IsDevelopment()
                ? new ApiException((int)HttpStatusCode.InternalServerError, ex.Message, ex.StackTrace.ToString())
                : new ApiResponse((int)HttpStatusCode.InternalServerError);

            // json serialization options
            var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };

            // serialize error response to json
            var json = JsonSerializer.Serialize(response, options);

            // write the json response to http response
            await context.Response.WriteAsync(json);
        }
    }
}
