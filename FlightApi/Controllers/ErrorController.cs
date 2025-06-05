using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace FlightApi.Controllers
{
    /// <summary>
    /// Controller responsible for handling application errors and returning standardized error responses.
    /// </summary>
    [ApiController]
    public class ErrorController : ControllerBase
    {
        /// <summary>
        /// Handles unhandled exceptions and returns a problem details response with error information.
        /// </summary>
        /// <returns>
        /// An <see cref="IActionResult"/> containing the problem details with error information.
        /// </returns>
        [Route("/error")]
        public IActionResult HandleError()
        {
            var context = HttpContext.Features.Get<IExceptionHandlerFeature>();
            var exception = context?.Error;

            return Problem(
                detail: exception?.Message,
                statusCode: 500,
                title: "An unexpected error occurred"
            );
        }
    }
}
