using System.Net;

namespace ApiRestResponseStandard.Utils;

public static class ApiResponseHandler
{
    public enum ResponseEnum
    {
        ERROR_SERVER = 100,
        SQL_ERROR = 1000,
        AUTH_ERROR = 2000,
        RESOURCE_SUCCESS = 3000,
        RESOURCE_NOT_FOUND = 3001,
        RESOURCE_UPDATED = 3002,
        RESOURCE_FOUND = 3003,
        RESOURCE_CREATE_SUCCESS = 3004,
        RESOURCE_CREATE_FAILED = 3005,
        RESOURCE_DELETE_SUCCESS = 3006,
        RESOURCE_DELETE_FAILED = 3007

    }
}

public static class ResponseEnumExtensions
{
   private static readonly Dictionary<ApiResponseHandler.ResponseEnum, (string description, int statusCode)> ResponseMappings  = new()
   {
       {ApiResponseHandler.ResponseEnum.AUTH_ERROR,("Error en la autenticacion.",(int)HttpStatusCode.Unauthorized)},
       {ApiResponseHandler.ResponseEnum.SQL_ERROR,("Hubo un error en la base de datos.", (int)HttpStatusCode.InternalServerError) },
       {ApiResponseHandler.ResponseEnum.ERROR_SERVER,("Hubo un error en la consulta.", (int)HttpStatusCode.InternalServerError) },
       {ApiResponseHandler.ResponseEnum.RESOURCE_CREATE_SUCCESS,("Recurso creado exitosamente.", (int)HttpStatusCode.Created) },
       {ApiResponseHandler.ResponseEnum.RESOURCE_CREATE_FAILED,("Error en la creacion del recurso.", (int)HttpStatusCode.BadRequest) },
       {ApiResponseHandler.ResponseEnum.RESOURCE_SUCCESS,("Recurso encontrado con exito.", (int)HttpStatusCode.OK)},
       {ApiResponseHandler.ResponseEnum.RESOURCE_NOT_FOUND,("No se encontro el recurso solicitado.", (int)HttpStatusCode.OK)},
       {ApiResponseHandler.ResponseEnum.RESOURCE_FOUND,("El recurso ingresado ya existe en la base de datos.", (int)HttpStatusCode.Conflict)},
       {ApiResponseHandler.ResponseEnum.RESOURCE_UPDATED,("Recurso actualizado con exito.", (int)HttpStatusCode.OK)},
       {ApiResponseHandler.ResponseEnum.RESOURCE_DELETE_SUCCESS,("Recurso eliminado con exito.", (int)HttpStatusCode.NoContent)},
       {ApiResponseHandler.ResponseEnum.RESOURCE_DELETE_FAILED,("Error al eliminar el recurso.", (int)HttpStatusCode.BadRequest)}
   };

   // Método para obtener la descripción de un código de respuesta
   public static string GetDescription(this ApiResponseHandler.ResponseEnum value)
   {
       return ResponseMappings[value].description;
   }

   // Método para obtener el código de estado HTTP de un código de respuesta
   public static int GetStatusCode(this ApiResponseHandler.ResponseEnum value)
   {
       return ResponseMappings[value].statusCode;
   }

   // Método para obtener el código de respuesta
   public static string GetResponseCode(this ApiResponseHandler.ResponseEnum value)
   {
       return $"Code_{(int)value}";
   }

}
