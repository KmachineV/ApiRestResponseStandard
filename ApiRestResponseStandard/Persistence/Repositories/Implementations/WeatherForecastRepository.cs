using ApiRestResponseStandard.Persistence.Repositories.Interfaces;

namespace ApiRestResponseStandard.Persistence.Repositories.Implementations;

public class WeatherForecastRepository : IWeatherForecastRepository
{
    
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };
    public Task<List<WeatherForecast>> GetWeatherForecast()
    {
        var weatherList = Enumerable.Range(1, 5).Select(index =>
            new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            }).ToList();
        return Task.FromResult(weatherList);
    }
}