namespace PayBridge.Shared;

public class ApiResponse<T>
{
    public bool success { get; set; }
    public string message { get; set; } = default!;
    public T? data { get; set; }

}
