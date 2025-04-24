using Lab4.Commands.FileCommands;

namespace Lab4.ResponsibilityChain.File;

public class FileShowHandler : BaseHandler
{
    private const string KeyWord = "show";
    private const string Mode = "console";
    private const string ModeKey = "-m";
    private const int CommandIndex = 1;
    private const int PathIndex = 2;

    public override HandlerResult Handle(IList<string> request)
    {
        if (request.Count < 3 || !request[CommandIndex].Equals(KeyWord, StringComparison.InvariantCultureIgnoreCase))
        {
            return Next?.Handle(request) ?? new HandlerResult.Fail();
        }

        int modeIndex = request.IndexOf(ModeKey);
        return request.Count == 3
            ? new HandlerResult.Success(new FileShow(request[PathIndex], string.Empty))
            : request[modeIndex + 1] == Mode ? new HandlerResult.Success(new FileShow(request[PathIndex], Mode)) : new HandlerResult.Fail();
    }
}