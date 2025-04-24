namespace Lab4.ResponsibilityChain;

public interface IHandler
{
    IHandler SetNext(IHandler handler);

    HandlerResult Handle(IList<string> request);
}