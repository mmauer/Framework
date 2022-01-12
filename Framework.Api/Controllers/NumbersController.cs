using Framework.Api.Commands;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Framework.Api.Controllers
{
    // Example of basic command usage

    [Route("api/[controller]")]
    [ApiController]
    public class NumbersController : ControllerBase
    {
        private readonly IResetNumberCommand command;

        public NumbersController(IResetNumberCommand command)
        {
            this.command = command;
        }

        [HttpPut, Route("")]
        public async Task<ActionResult> Reset([FromBody] int number)
        {
            var result = command.Execute(number);

            if (result.IsSuccess) return Ok(result);
           
            return BadRequest(result);
        }
    }
}
