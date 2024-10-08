namespace Kent.SpareBank1.ApiClient;

public class ApiClientResult<T>
{
    public T? Value { get; set; }
    public bool IsSuccess { get; set; }
    public string? ErrorMessage { get; set; }
}