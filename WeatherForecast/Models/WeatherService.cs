using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using WeatherForecast.Services;

namespace WeatherForecast.Models
{
    public interface IWeatherService
    {
        Task<List<Forecast>> GetWeather(RequestOptions requestOptions);
    }

    public class WeatherService : IWeatherService
    {
        ILogger<IWeatherService> _logger;
        public WeatherService(ILogger<IWeatherService> logger)
        {
            _logger = logger;
        }

        public async Task<List<Forecast>> GetWeather(RequestOptions requestOptions)
        {
            var httpClient = new HttpClient(new LoggingHandler(new HttpClientHandler(), _logger));

            HttpResponseMessage response = new HttpResponseMessage();
            string result = "";
            RootObject data = new RootObject();

            try
            {
                response = await httpClient.GetAsync("https://api.openweathermap.org/data/2.5/forecast?appid=77bea68862c21b7c9eb039c704002d81" + requestOptions.ToString());
                result = await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Problem with HttpClient!");
                _logger.LogError(ex.ToString());
                throw;
            }

            try
            {
                data = JsonConvert.DeserializeObject<RootObject>(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Serilization failed!");
                _logger.LogError(ex.ToString());
                throw;
            }

            var preparedData = PrepareDataForView(requestOptions, data);

            return preparedData;
        }

        private List<Forecast> PrepareDataForView(RequestOptions requestOptions, RootObject data)
        {
            List<Forecast> listOfData = new List<Forecast>();
            var currentDate = DateTime.Now;
            var endDate = DateTime.Now.AddDays(requestOptions.Period - 1);

            try
            {
                var listOfDays = data.list.TakeWhile(x => x.dt_txt.Date <= endDate).ToList();
                var averagePressure = Math.Round(listOfDays.Average(x => x.main.pressure), 2);

                listOfData = listOfDays.GroupBy(x => x.dt_txt.Date).Select((x => new Forecast { City = requestOptions.City, Date = x.Key, Unit = requestOptions.GetStandartUnit(), AverageTemperature = Math.Round(x.Average(p => p.main.temp), 2), Rain = "", AveragePressure = averagePressure })).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }
            return listOfData;
        }
    }
}
