using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherForecastService.Test
{
    public class WeatherForecastTests
    {
        [Theory]
        [InlineData(0, 32)]
        [InlineData(100, 211)]
        [InlineData(-40, -39)]
        public void TemperatureF_IsCalculatedCorrectly(int temperatureC, int expectedTemperatureF)
        {
            // Arrange
            var date = DateOnly.FromDateTime(DateTime.Now);
            var summary = "Test";

            // Act
            var forecast = new WeatherForecast.Service.Models.WeatherForecast(date, temperatureC, summary);

            // Assert
            Assert.Equal(expectedTemperatureF, forecast.TemperatureF);
        }

        [Fact]
        public void WeatherForecast_StoresValuesCorrectly()
        {
            // Arrange
            var date = DateOnly.FromDateTime(DateTime.Now);
            var temperatureC = 25;
            var summary = "Sunny";

            // Act
            var forecast = new WeatherForecast.Service.Models.WeatherForecast(date, temperatureC, summary);

            // Assert
            Assert.Equal(date, forecast.Date);
            Assert.Equal(temperatureC, forecast.TemperatureC);
            Assert.Equal(summary, forecast.Summary);
        }
    }
}
