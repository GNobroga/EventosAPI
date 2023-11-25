using System.Text.Json;

namespace EventoAPI.Application.Helpers;

public class AppError : Exception 
{
    public string Status { get; set; } = "Error";
    public int StatusCode { get; set; }

    public AppError(string message, int code = 500) : base (message)
    {
        StatusCode = code;
    }

    public override string ToString()
    {
        return JsonSerializer.Serialize(new {
            status = Status,
            statusCode = StatusCode,
            message = Message
        });
    }

}