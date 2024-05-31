namespace ApiRestResponseStandard.Utils;

public class ApiResponseModel<T>
{
    public string? Message { get; set;}
    public int? Operation {get; set;} 

    public int StatusCode { get; set;}
    public T? Response { get; set;}
}