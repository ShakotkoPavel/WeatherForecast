using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherForecast.Models
{
    public interface IWeatherService
    {
        void GetWeather();
    }

    public class WeatherService : IWeatherService
    {
        public void GetWeather()
        {

        }
    }
}
