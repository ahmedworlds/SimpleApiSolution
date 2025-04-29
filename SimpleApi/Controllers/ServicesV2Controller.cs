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



        [HttpGet("Sum")]
        public IActionResult GetSum(int a, int b)
        {
            var sum = a + b;
            return Ok(new{result = sum});
        }



    }
    

}