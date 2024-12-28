using System.Diagnostics.CodeAnalysis;

namespace PayConnect.Payment.WebApi.Shared;

public class ApiResponse<T> where T : class
{
    public bool HasError { get; set; }
    public T? Data { get; set; }
    public string? Error { get; set; }

    [SuppressMessage("JsonConstructor", "CS8618", Justification = "For serialization purposes")]
    public ApiResponse()
    {
        
    }

    public ApiResponse(T data)
    {
        HasError = false;
        Data = data;
        Error = null;
    }
    
    public ApiResponse(string error)
    {
        HasError = true;
        Data = null;
        Error = error;
    }
}

