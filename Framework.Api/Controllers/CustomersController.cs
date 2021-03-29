using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Framework.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {

        // Doing the rule service, rule group thing
        [HttpGet, Route("")]
        public async Task<ActionResult> Customers([FromQuery] int type)
        {
            return Ok(type);
        }
    }
}
