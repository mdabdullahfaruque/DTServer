using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherForecast.Service.Interfaces
{
    public interface IWeatherForecastService
    {
        IEnumerable<Models.WeatherForecast> GetWeatherForecasts();
    }
}
