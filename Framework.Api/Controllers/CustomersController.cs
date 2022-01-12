using Framework.Core;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Framework.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        [HttpGet, Route("")]
        public async Task<ActionResult> Customers([FromQuery] int number)
        {
            var result = Result<int>.Success(number, "Success!");

            result.AddMessage("Some additional messaging");

            return Ok(result);
        }
    }
}
