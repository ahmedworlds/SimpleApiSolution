using Microsoft.AspNetCore.Mvc;

namespace SimpleApi.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class WeatherController : ControllerBase
    {

        [HttpGet]
        public IActionResult GetWeather()
        {
            var weatherData = new
            {
                TemperatureC = 25,
                Summary = "Sunny"
            };

            return Ok(weatherData);
        }



        [HttpGet("city")]
        public IActionResult GetWeatherByCity(string city)
        {
            var weatherData = new 
            {
                City = city,
                TemperatureC = 25,
                Summary = "Sunny"   
            };

            return Ok(weatherData);
        }
        


    }
}