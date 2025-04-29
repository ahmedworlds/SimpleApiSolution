using System;
using Microsoft.AspNetCore.Mvc;


namespace SimpleApi.Controllers
{


    [ApiController]
    [Route("api/v1/Services")]
    // [Route("api/v1/[controller]")]
    // [ApiVersion("1.0")]
    // [Route("api/v1/Services")]
    // [Route("[controller]")]
    public class ServicesV1Controller : ControllerBase
    {
        [HttpGet]
        // [ApiVersion("1.0")]
        public IActionResult Info()
        {
            return Ok($"Service is running {System.DateTime.UtcNow}");
        }

        [HttpGet("RandomNumber")]
        // [ApiVersion("1.0")]
        public IActionResult GetRandomNumber()
        {
            return Ok(new { result = new Random().Next(1, 1000) });
        }

    }



}






