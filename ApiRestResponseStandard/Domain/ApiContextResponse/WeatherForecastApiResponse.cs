using System.Net;
using ApiRestResponseStandard.Utils;

namespace ApiRestResponseStandard.Domain.ApiContextResponse;

public class WeatherForecastApiResponse
{
    public static ApiUtilsConst SUCCESS = new() {  Code = 1000,  Description = "La solicitud se realizó correctamente.",  StatusCode = HttpStatusCode.OK };
    public static ApiUtilsConst ERROR = new() {  Code = 2000,  Description = "Se ha producido un error inesperado.",  StatusCode = HttpStatusCode.InternalServerError };   
    public static ApiUtilsConst NOT_FOUND = new() {  Code = 2001,  Description = "El recurso solicitado no existe.",  StatusCode = HttpStatusCode.NotFound };
    public static ApiUtilsConst BAD_REQUEST = new() {  Code = 2002,  Description = "Hubo un error en la solcitud del cliente.",  StatusCode = HttpStatusCode.BadRequest };
    public static ApiUtilsConst UNAUTHORIZED = new() {  Code = 2003,  Description = "No tiene autorizacion para acceder al recurso",  StatusCode = HttpStatusCode.Unauthorized };
}