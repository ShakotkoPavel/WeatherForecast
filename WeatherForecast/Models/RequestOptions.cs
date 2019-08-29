using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherForecast.Models
{
    public class RequestOptions
    {
        public string City { get; set; }

        public string Unit { get; set; }

        public string Language { get; set; }

        public short Period { get; set; }

        public RequestOptions()
        {

        }

        public override string ToString()
        {
            return "&q=" + this.City + "&units=" + this.Unit + "&lang=" + this.Language;
        }

        public string GetStandartUnit()
        {
            return Unit == "imperial" ? "Fahrenheit" : Unit == "metric" ? "Celsius" : "Kelvin";
        }
    }
}
