using ApiRestResponseStandard.Utils;
using Microsoft.AspNetCore.Mvc;

namespace ApiRestResponseStandard.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };
    
    

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public async Task<IActionResult> Get()
    {
        ApiResponseModel<IEnumerable<WeatherForecast>> response = new()
        {
            Message = ApiResponseHandler.ResponseEnum.RESOURCE_SUCCESS.GetDescription(),
            Operation = ApiResponseHandler.ResponseEnum.RESOURCE_SUCCESS.GetResponseCode(),
            StatusCode = ApiResponseHandler.ResponseEnum.RESOURCE_SUCCESS.GetStatusCode(),
            Response = Enumerable.Range(1, 5).Select(index => new WeatherForecast
                {
                    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
                })
                .ToArray()
        };
        return StatusCode(response.StatusCode, response);
    }
}