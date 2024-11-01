using Microsoft.AspNetCore.Mvc;
using WebForescasts.Model;

namespace WebForescasts.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly WeatherForecatHolder _weatherForecatHolder;

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, WeatherForecatHolder weatherForecatHolder)
        {
            _logger = logger;
            _weatherForecatHolder = weatherForecatHolder;
        }

        [HttpGet("GetAll")]
        public IEnumerable<WeatherForecast> GetAll()
        {
            return _weatherForecatHolder.GetAll();
        }

        [HttpPost("add")]
        public IActionResult Add([FromQuery] DateTime date, [FromQuery] int temperature)
        {
            _weatherForecatHolder.Add(new WeatherForecast { Date = date, TemperatureC = temperature });
            return Ok();
        }
        [HttpPut("delete")]
        public IActionResult Delete([FromQuery] DateTime date)
        {
            bool res = _weatherForecatHolder.Delete(date);
            if (res)
                return Ok();
            else
                return NotFound();
        }

        [HttpGet("get")]
        public IActionResult Get([FromQuery] DateTime dateFrom, [FromQuery] DateTime dateTo)
        {
            List<WeatherForecast> forecasts = _weatherForecatHolder.Get(dateFrom, dateTo).ToList();
            if (forecasts is not null && forecasts.Count > 0)
                return Ok(forecasts);
            else
                return StatusCode(500);
        }
    }
}
