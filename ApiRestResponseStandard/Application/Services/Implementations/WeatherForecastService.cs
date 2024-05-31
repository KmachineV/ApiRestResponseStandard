using ApiRestResponseStandard.Application.Services.Interfaces;
using ApiRestResponseStandard.Persistence.Repositories.Interfaces;
using ApiRestResponseStandard.Utils;
using ApiRestResponseStandard.Domain.ApiContextResponse;

namespace ApiRestResponseStandard.Application.Services.Implementations;

public class WeatherForecastService : IWeatherForecastServices
{
    private readonly IWeatherForecastRepository _weatherForecastRepository;

    public WeatherForecastService(IWeatherForecastRepository weatherForecastRepository)
    {
        _weatherForecastRepository = weatherForecastRepository;
    }

    public async Task<ApiResponseModel<List<WeatherForecast>>> GetWeatherForecast()
    {
        var result = await _weatherForecastRepository.GetWeatherForecast();
        return ApiResponseHandler.GetApiResponse(result != null ? WeatherForecastApiResponse.SUCCESS : WeatherForecastApiResponse.ERROR, result);
    }

    public async Task<ApiResponseModel<string>> GetWeatherForecastError()
    {
        return ApiResponseHandler.GetApiResponse(WeatherForecastApiResponse.ERROR, "Exception");
    }

    public async Task<ApiResponseModel<WeatherForecast?>> GetWeatherForecastNotFound()
    {
        var result = await _weatherForecastRepository.GetWeatherForecast();
        var findresult = result.Find(a => a.Summary == "XD");
        if(findresult == null)
        {
            findresult = null;
            return ApiResponseHandler.GetApiResponse<WeatherForecast?>(WeatherForecastApiResponse.NOT_FOUND, findresult);
        }
        return ApiResponseHandler.GetApiResponse(WeatherForecastApiResponse.SUCCESS, findresult);
        
    }
}