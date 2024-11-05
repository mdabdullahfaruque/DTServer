using Microsoft.Extensions.Options;
using WeatherForecast.Service.Interfaces;
using WeatherForecast.Service.Services;

namespace WeatherForecast.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthorization();

            var allowedOrigins = builder.Configuration.GetSection("AllowedOrigins").Get<string[]>(); ;
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigins", policy =>
                {
                    policy.WithOrigins(allowedOrigins ?? [])
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });

            builder.Services.AddScoped<IWeatherForecastService, WeatherForecastService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapGet("/weatherforecast", (IWeatherForecastService service) => service.GetWeatherForecasts())
                .WithName("GetWeatherForecast");

            app.UseCors("AllowSpecificOrigins");

            app.Run();
        }
    }
}
