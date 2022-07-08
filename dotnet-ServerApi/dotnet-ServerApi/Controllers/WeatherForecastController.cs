using Microsoft.AspNetCore.Mvc;

namespace dotnet_ServerApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet("weather/{cityId}/{unit}")]
        public dynamic GetWeather(int cityId, string unit)
        {
            try
            {
                return Classes.Weather.Get(cityId, unit);
            }
            catch(Exception e)
            {
                return NotFound(e.Message);
            }
        }
        //get cities information that contains a certain cityName
        [HttpGet("getcities/{cityName}")]
        public dynamic GetCity(string cityName)
        {
            try
            {
                return Classes.Geo.GetCitiesInformation(cityName);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}