namespace Lab4;

public abstract record OperationResult
{
    public sealed record Success : OperationResult;

    public sealed record Fail(string ErrorMessage) : OperationResult;
}