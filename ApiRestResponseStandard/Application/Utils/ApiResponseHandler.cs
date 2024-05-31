using System.Net;

namespace ApiRestResponseStandard.Utils;

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