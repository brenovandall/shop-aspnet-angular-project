using Microsoft.AspNetCore.Mvc;
using shop_api.Errors;

namespace shop_api.Controllers
{
    [Route("errors/{code}")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorController : UrlHandleApiBaseController
    {
        public IActionResult Error(int code)
        {
            // if no endpoints matches the request,
            // it gets the endpoint at program.cs builder
            return new ObjectResult(new ApiResponse(code)); 
        }
    }
}