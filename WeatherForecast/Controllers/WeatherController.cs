using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WeatherForecast.Models;

namespace WeatherForecast.Controllers
{
    [Route("api/weather")]
    public class WeatherController : Controller
    {
        readonly IWeatherService _weatherService;
        readonly ISaveService _saveService;

        public WeatherController(IWeatherService weatherService, ISaveService saveService)
        {
            _weatherService = weatherService;
            _saveService = saveService;
        }

        [HttpGet]
        public async Task<IActionResult> GetWeather(RequestOptions options)
        {
            List<Forecast> data = null;

            await RetryHelper.RetryOnExceptionAsync(3, TimeSpan.FromSeconds(5), async () => {
                data = await _weatherService.GetWeather(options);
            });

            try
            {
                await _saveService.SaveForecast(data);
                return Ok(data);
            }
            catch(Exception ex)
            {
                return BadRequest(data);
            }
        }
    }
}
