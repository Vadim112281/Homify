namespace Homify.Monolith.Application.Common.Results;

public sealed class Result<T>
{
    public bool IsSuccess { get; init; }
    public T? Data { get; init; }
    public IReadOnlyList<string>? Errors { get; init; }

    public static Result<T> Success(T? data = default)
        => new() { IsSuccess = true, Data = data };

    public static Result<T> Failure(List<string>? errors)
    {
        return new Result<T> ()
        {
            IsSuccess = false,
            Errors = errors is { Count: > 0 } ? errors : null
        };
    }
}