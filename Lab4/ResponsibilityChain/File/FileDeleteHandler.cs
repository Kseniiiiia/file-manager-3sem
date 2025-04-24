using Lab4.Commands.FileCommands;

namespace Lab4.ResponsibilityChain.File;

public class FileDeleteHandler : BaseHandler
{
    private const string KeyWord = "delete";
    private const int CommandIndex = 1;
    private const int PathIndex = 2;

    public override HandlerResult Handle(IList<string> request)
    {
        return request.Count < 3 || !request[CommandIndex].Equals(KeyWord, StringComparison.InvariantCultureIgnoreCase)
            ? Next?.Handle(request) ?? new HandlerResult.Fail()
            : new HandlerResult.Success(new FileDelete(request[PathIndex]));
    }
}