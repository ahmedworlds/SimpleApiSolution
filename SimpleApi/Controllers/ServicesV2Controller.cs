using System;
using Microsoft.AspNetCore.Mvc;


namespace SimpleApi.Controllers
{

    
    [ApiController]
    [Route("api/v2/Services")]
    // [Route("api/v2/[controller]")]
    // [ApiVersion("2.0")]
    public class ServicesV2Controller : ControllerBase
    {


        [HttpGet]
        // [ApiVersion("2.0")]
        public IActionResult Info()
        {
            return Ok($"Service is running {System.DateTime.UtcNow}");
        }



        [HttpGet("RandomNumber")]
        // [ApiVersion("2.0")]
        public IActionResult GetRandomNumber()
        {
            return Ok(new { result = new Random().Next(1, 1000) });
        }




        [HttpPost("Sum")]
        public IActionResult GetSum([FromForm, FromQuery] int a, [FromForm, FromQuery] int b)
        {
            var sum = a + b;
            return Ok(new{result = sum});
        }



        [HttpPost("Multiply")]
        public IActionResult GetMultiply([FromForm, FromQuery] int a, [FromForm, FromQuery] int b)
        {
            var multiply = a * b;
            return Ok(new{result = multiply});
        }


    }
    

}