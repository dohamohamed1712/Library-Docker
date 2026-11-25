namespace Library.API.Results;

public class GenericResult<T> : Result
{
    public T? Data { get; set; }

    public static GenericResult<T> Ok(T data, string? message = null) => new() { Success = true, Data = data, Message = message };
    public static new GenericResult<T> Fail(string message) => new() { Success = false, Message = message };
}
