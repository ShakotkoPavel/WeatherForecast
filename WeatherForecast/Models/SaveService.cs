using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherForecast.Models
{
    public interface ISaveService
    {
        Task SaveForecast(List<Forecast> forecasts);
    }
    public class SaveService : ISaveService
    {
        readonly ApplicationContext _context;
        readonly ILogger<ISaveService> _logger;
        public SaveService(ApplicationContext context, ILogger<ISaveService> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task SaveForecast(List<Forecast> forecasts)
        {
            foreach (Forecast item in forecasts)
            {
                _context.Forecasts.Add(item);
            }
            await _context.SaveChangesAsync();
        }
    }
}
