using Lab4.Commands;

namespace Lab4.ResponsibilityChain;

public class ConnectHandler : BaseHandler
{
    private const string KeyWord = "connect";
    private const string Mode = "local";
    private const string ModeKey = "-m";
    private const int CommandIndex = 0;
    private const int PathIndex = 1;

    public override HandlerResult Handle(IList<string> request)
    {
        if (request.Count < 2 || !request[CommandIndex].Equals(KeyWord, StringComparison.InvariantCultureIgnoreCase))
        {
            return Next?.Handle(request) ?? new HandlerResult.Fail();
        }

        string? mode = string.Empty;
        int modeIndex = request.IndexOf(ModeKey);
        return modeIndex > 0
            ? request[modeIndex + 1] == Mode ? new HandlerResult.Success(new Connect(request[PathIndex], Mode)) : new HandlerResult.Fail()
            : new HandlerResult.Success(new Connect(request[PathIndex], mode));
    }
}