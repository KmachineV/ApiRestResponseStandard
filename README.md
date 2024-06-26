Estandarización de Respuesta API con REST - Proyecto .NET
Este README proporciona una visión general de la estandarización de las respuestas API para un proyecto .NET utilizando la arquitectura REST. El proceso de estandarización asegura respuestas consistentes y significativas a lo largo de la API, mejorando la experiencia de los desarrolladores y usuarios.

# Descripción General
El código proporcionado define una clase ApiResponseHandler que estandariza las respuestas API mapeando los códigos de estado a descripciones y mensajes de estado significativos. Esto ayuda a crear una estructura unificada para todas las respuestas API.

# Implementación
Clase ApiResponseHandler
La clase ApiResponseHandler es responsable de manejar y formatear las respuestas API. Utiliza un diccionario para mapear constantes de utilidades API a sus respectivas descripciones y códigos de estado, asegurando que las respuestas sean consistentes.

```csharp

public class ApiResponseHandler
{
    private static readonly Dictionary<int, ApiUtilsConst> ResponseMappings = new();

    public static ApiResponseModel<T?> GetApiResponse<T>(ApiUtilsConst apiUtilsConst, T? response)
    {
        // Actualiza el diccionario de mapeo de respuestas
        ResponseMappings[apiUtilsConst.Code] = new ApiUtilsConst()
        {
            Code = apiUtilsConst.Code,
            Description = apiUtilsConst.Description,
            StatusCode = apiUtilsConst.StatusCode
        };

        // Genera el ApiResponseModel
        var apiResponse = new ApiResponseModel<T?>
        {
            Message = ResponseMappings.TryGetValue(apiUtilsConst.Code, out var mappedResponse) ? mappedResponse.Description : "Error desconocido",
            Operation = apiUtilsConst.Code,
            StatusCode = (int)(mappedResponse?.StatusCode ?? HttpStatusCode.InternalServerError),
            Response = response
        };

        return apiResponse;
    }
}
```

# Componentes
Clase ApiUtilsConst
Esta clase contiene constantes utilizadas para mapear las respuestas API. Incluye propiedades como "Code", "Description" y "StatusCode".
```csharp
public class ApiUtilsConst
{
    public int Code { get; set; }
    public string Description { get; set; }
    public HttpStatusCode StatusCode { get; set; }
}
```

Clase ApiResponseModel<T>
La clase ApiResponseModel representa la estructura estandarizada de la respuesta API. Incluye las siguientes propiedades:
```csharp
public class ApiResponseModel<T>
{
    public string? Message { get; set;}
    public int? Operation {get; set;}
    public int StatusCode { get; set;}
    public T? Response { get; set;}
} 
```

# Ejemplo
* Service
```csharp
public async Task<ApiResponseModel<WeatherForecast?>> GetWeatherForecastNotFound()
{
    var result = await _weatherForecastRepository.GetWeatherForecast();
    var findresult = result.Find(a => a.Summary == "XD");
    if(findresult == null)
    {
         return ApiResponseHandler.GetApiResponse<WeatherForecast?>(WeatherForecastApiResponse.NOT_FOUND, null);
    }
    return ApiResponseHandler.GetApiResponse(WeatherForecastApiResponse.SUCCESS, findresult);

}
```
* Controller

```csharp
[HttpGet("notfound", Name = "GetWeatherForecastNotFound")]
public async Task<IActionResult> GetNotFound()
{
    var result = await _weatherForecastService.GetWeatherForecastNotFound();
    return StatusCode(result.StatusCode, result);
}
```

# Beneficios
* Consistencia: Asegura que todas las respuestas API sigan una estructura consistente, facilitando el manejo de respuestas en el lado del cliente.


* Claridad: Proporciona mensajes claros y descriptivos para cada respuesta, ayudando en la depuración y mejorando la experiencia del usuario. Asi como tambien retornar el codigo de estado HTTP correspondiente.


* Mantenibilidad: Centraliza la lógica de manejo de respuestas, haciendo que el código sea más fácil de mantener y extender.