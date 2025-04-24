namespace Lab4.ResponsibilityChain;

public abstract class BaseHandler : IHandler
{
    protected IHandler? Next { get; private set; }

    public IHandler SetNext(IHandler handler)
    {
        if (Next is null)
        {
            Next = handler;
        }
        else
        {
            Next.SetNext(handler);
        }

        return this;
    }

    public abstract HandlerResult Handle(IList<string> request);
}