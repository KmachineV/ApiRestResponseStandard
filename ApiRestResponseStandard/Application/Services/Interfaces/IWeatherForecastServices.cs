using ApiRestResponseStandard.Utils;

namespace ApiRestResponseStandard.Application.Services.Interfaces;

public interface IWeatherForecastServices
{
    Task<ApiResponseModel<List<WeatherForecast>>> GetWeatherForecast();
    Task<ApiResponseModel<string>> GetWeatherForecastError();
    Task<ApiResponseModel<WeatherForecast?>> GetWeatherForecastNotFound();
}