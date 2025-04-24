namespace Lab4.States;

public abstract record StateResult
{
    private StateResult() { }

    public sealed record Success(IStateHandler Next) : StateResult;

    public sealed record Invalid(string Message) : StateResult;
}