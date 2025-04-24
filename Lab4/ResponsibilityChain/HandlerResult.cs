using Lab4.Commands;

namespace Lab4.ResponsibilityChain;

public abstract record HandlerResult
{
    public sealed record Success(ICommand Command) : HandlerResult;

    public sealed record Fail() : HandlerResult;
}