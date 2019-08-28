using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WeatherForecast.Models;

namespace WeatherForecast.Controllers
{
    [Route("api/weather")]
    public class WeatherController : Controller
    {
        ApplicationContext db;
        public WeatherController(ApplicationContext context)
        {
            db = context;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Weather weather)
        {
            if (ModelState.IsValid)
            {
                db.Weather.Add(weather);
                await db.SaveChangesAsync();
                return Ok(weather);
            }
            return BadRequest(weather);
        }

        [HttpGet]
        public async Task<IActionResult> GetWeather(RequestOptions options)
        {
            return Ok();
        }

        //public class WeatherForecast
        //{
        //    public string DateFormatted { get; set; }
        //    public int TemperatureC { get; set; }
        //    public string Summary { get; set; }

        //    public int TemperatureF
        //    {
        //        get
        //        {
        //            return 32 + (int)(TemperatureC / 0.5556);
        //        }
        //    }
        //}
    }
}
