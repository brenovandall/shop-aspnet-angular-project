namespace shop_api.Errors;
public class ApiResponse
{
    // here is the base class to define the errors
    public ApiResponse(int statusCode, string message = null)
    {
        StatusCode = statusCode;
        Message = message ?? GetDefaultMessageForStatusCode(statusCode);
    }

    public int StatusCode { get; set; }
    public string Message { get; set; }

    private string GetDefaultMessageForStatusCode(int statusCode)
    {
        return statusCode switch
        {
            400 => "Oops! Your request couldn't be processed. Please check if you provided valid data and try again.",
            401 => "Unauthorized access! It seems you don't have the necessary permissions to access this resource. Please log in or authenticate to proceed.",
            404 => "404 Error: Page not found. The requested resource could not be located. Please verify the URL and try another one.",
            500 => "Oops! Something went wrong on our end. Our team has been notified, and we're working to fix the issue. Please try again later.",
            _ => null
        };
    }
}
