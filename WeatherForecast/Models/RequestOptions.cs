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
    }
}
