namespace WeatherForecastService.Test
{
    public class WeatherForecastServiceTests
    {
        [Fact]
        public void GetWeatherForecasts_ShouldReturnFiveForecasts()
        {
            // Arrange
            var weatherForecastService = new WeatherForecast.Service.Services.WeatherForecastService();

            // Act
            var result = weatherForecastService.GetWeatherForecasts();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(5, result.Count());
        }

        [Fact]
        public void GetWeatherForecasts_ShouldReturnValidSummaries()
        {
            // Arrange
            var weatherForecastService = new WeatherForecast.Service.Services.WeatherForecastService();
            var validSummaries = new[] { "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching" };

            // Act
            var result = weatherForecastService.GetWeatherForecasts();

            // Assert
            foreach (var forecast in result)
            {
                Assert.Contains(forecast.Summary, validSummaries);
            }
        }

        [Fact]
        public void GetWeatherForecasts_ShouldReturnValidTemperatures()
        {
            // Arrange
            var weatherForecastService = new WeatherForecast.Service.Services.WeatherForecastService();

            // Act
            var result = weatherForecastService.GetWeatherForecasts();

            // Assert
            foreach (var forecast in result)
            {
                Assert.InRange(forecast.TemperatureC, -20, 55);
            }
        }

        [Fact]
        public void GetWeatherForecasts_SummariesShouldBeRandomlySelected()
        {
            // Arrange
            var service = new WeatherForecast.Service.Services.WeatherForecastService();

            // Act
            var firstRun = service.GetWeatherForecasts().Select(f => f.Summary).ToList();
            var secondRun = service.GetWeatherForecasts().Select(f => f.Summary).ToList();

            // Assert
            Assert.NotEqual(firstRun, secondRun);
        }
    }
}
