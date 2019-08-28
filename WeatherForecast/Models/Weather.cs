using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherForecast.Models
{
    public class Weather
    {
        public int Id { get; set; }

        public string City { get; set; }

        public DateTime? Date { get; set; }

        public string Unit { get; set; }

        public double AverageTemperature { get; set; }

        public string Rain { get; set; }

        public double AveragePressure { get; set; }
    }
}
