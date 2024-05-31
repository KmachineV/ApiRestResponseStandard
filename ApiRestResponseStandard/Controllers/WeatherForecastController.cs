using ApiRestResponseStandard.Application.Services.Interfaces;
using ApiRestResponseStandard.Utils;
using Microsoft.AspNetCore.Mvc;

namespace ApiRestResponseStandard.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly IWeatherForecastServices _weatherForecastService;

    private readonly ILogger<WeatherForecastController> _logger;
    public WeatherForecastController(ILogger<WeatherForecastController> logger,
        IWeatherForecastServices weatherForecastService)
    {
        _logger = logger;
        _weatherForecastService = weatherForecastService;
    }

    /// <summary>
    /// Metodo que devuelve un 200
    /// </summary>
    /// <returns> Retorna un 200 </returns>
    [HttpGet(Name = "GetWeatherForecast")]
    public async Task<IActionResult> Get()
    {
        var result = await _weatherForecastService.GetWeatherForecast();
        return StatusCode(result.StatusCode, result);
    }
    
    /// <summary>
    /// Metodo que devuelve un error 500
    ///</summary>
    
    [HttpGet("error", Name = "GetWeatherForecastError")]
    public async Task<IActionResult> GetError()
    {
        var result = await _weatherForecastService.GetWeatherForecastError();
        return StatusCode(result.StatusCode, result);
    }
    
    /// <summary>
    /// Metodo que devuelve un Not Found 404
    ///</summary>
    
    [HttpGet("notfound", Name = "GetWeatherForecastNotFound")]
    public async Task<IActionResult> GetNotFound()
    {
        var result = await _weatherForecastService.GetWeatherForecastNotFound();
        return StatusCode(result.StatusCode, result);
    }
}