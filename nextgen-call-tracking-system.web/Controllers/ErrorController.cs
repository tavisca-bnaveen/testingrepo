using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using nextgen_call_tracking_system.Models;

namespace nextgen_call_tracking_system.web.Controllers
{
    [EnableCors("MyPolicy")]
    [ApiController]
    public class ErrorController : ControllerBase
    {

        [Route("api/Error/{StatusCode}")]
        public ActionResult HttpStatusCodeHandler(int StatusCode)
        {
            var values = new List<Report>();
            switch (StatusCode)
            {
                case 404:
                    return NotFound(new Output { Error = "NotFound", Values = values });
                default:
                    return BadRequest(new Output { Error = "Exception", Values = values });
            }
        }

    }

}
