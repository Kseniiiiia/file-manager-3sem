using Lab4.Commands;

namespace Lab4.ResponsibilityChain;

public class DisconnectHandler : BaseHandler
{
    private const string KeyWord = "disconnect";
    private const int CommandIndex = 0;

    public override HandlerResult Handle(IList<string> request)
    {
        return request.Count > 1 || !request[CommandIndex].Equals(KeyWord, StringComparison.InvariantCultureIgnoreCase)
            ? Next?.Handle(request) ?? new HandlerResult.Fail()
            : new HandlerResult.Success(new Disconnect());
    }
}