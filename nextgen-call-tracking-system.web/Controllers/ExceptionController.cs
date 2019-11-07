using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using nextgen_call_tracking_system.Models;

namespace nextgen_call_tracking_system.web.Controllers
{
    [EnableCors("MyPolicy")]
    [ApiController]
    public class ExceptionController : ControllerBase
    {
        [Route("api/Exception")]
        public ActionResult CustomException()
        {
            var values = new List<Report>();
            var ExceptionDetails = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            
            if (ExceptionDetails != null)
            {
                var error = new Output { Values = values, Error = ExceptionDetails.Error.Message };
                return BadRequest(error);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
