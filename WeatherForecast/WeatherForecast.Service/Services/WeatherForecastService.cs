using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherForecast.Service.Interfaces;

namespace WeatherForecast.Service.Services
{
    public class WeatherForecastService : IWeatherForecastService
    {
        private static readonly string[] summaries =
        [
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        ];


        public IEnumerable<Models.WeatherForecast> GetWeatherForecasts()
        {
            var forecast = Enumerable.Range(1, 5).Select(index =>
                new Models.WeatherForecast
                (
                    DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    Random.Shared.Next(-20, 55),
                    summaries[Random.Shared.Next(summaries.Length)]
                ));

            return forecast;
        }
    }
}
