namespace ApiRestResponseStandard.Utils;

public class ApiResponseModel<T>
{
    public string? Message { get; set;}
    public string? Operation {get; set;} 

    public int StatusCode { get; set;}
    public T? Response { get; set;}
}