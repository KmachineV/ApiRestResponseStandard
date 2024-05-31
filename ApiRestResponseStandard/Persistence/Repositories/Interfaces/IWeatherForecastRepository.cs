namespace ApiRestResponseStandard.Persistence.Repositories.Interfaces;

public interface IWeatherForecastRepository
{
    Task<List<WeatherForecast?>> GetWeatherForecast();
}