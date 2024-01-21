using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using shop_api.Errors;
using shop_api.Data;

namespace shop_api.Controllers;

//THIS CONTROLLER MAKES THE ERROR HANDLING
public class ErrorHandlingController : UrlHandleApiBaseController
{
    private readonly ApplicationStoreDbContext _context;

    public ErrorHandlingController(ApplicationStoreDbContext context)
    {
        _context = context;
    }

    [HttpGet("notfound")]
    public IActionResult GetNotFound()
    {
        var productNotFound = _context.Products_Table.Find(10);

        if (productNotFound == null)
        {
            return NotFound(new ApiResponse(404)); // gets the 404 error from [Controllers\Errors\ApiResponse.cs]
        }

        return Ok();
    }

    [HttpGet("servererror")]
    public IActionResult GetServerError()
    {
        var product = _context.Products_Table.Find(1000);

        var productToReturn = product.ToString(); // if the product doesnt exists, basically it cant be converted to a string, so it will returns a 500 server error

        return Ok();
    }

    [HttpGet("badrequest")]
    public IActionResult GetBadRequest()
    {
        return BadRequest(new ApiResponse(400)); // gets the 400 error from [Controllers\Errors\ApiResponse.cs]
    }

    [HttpGet("badrequest/{id}")]
    public IActionResult GetBadRequest(int id)
    {
       return BadRequest();
    }
}
