using System.Net;

namespace ApiRestResponseStandard.Utils;

public class ApiUtilsConst
{
    public int Code { get; set; }
    public string Description { get; set; }
    public HttpStatusCode StatusCode { get; set; }
}