using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using nextgen_call_tracking_system.DAL.DatabaseModels;
using nextgen_call_tracking_system.Service.UserCredentialsService;

namespace nextgen_call_tracking_system.web.Controllers
{
    [EnableCors("MyPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserCredentialsService _service;
        public UserController(IUserCredentialsService service)
        {
            _service = service;
        }


        // GET api/values/Login
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody]UserCredentials user)
        {
            var response = await _service.VerifyUser(user);
            if (response == "Login successfull")
                return Ok(response);
            return NotFound(response);
        }

        [HttpGet("ChangePassword")]
        public async Task<IActionResult> ChangePassword([FromQuery]string userId)
        {
            var response = await _service.ChangePassword(userId);
            if (response == "successfully updated")
                return Ok(response);
            return BadRequest(response);
        }
    }
}
