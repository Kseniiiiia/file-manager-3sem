using Lab4.Commands.FileCommands;

namespace Lab4.ResponsibilityChain.File;

public class FileCopyHandler : BaseHandler
{
    private const string KeyWord = "copy";
    private const int CommandIndex = 1;
    private const int InitPathIndex = 2;
    private const int FinalPathIndex = 3;

    public override HandlerResult Handle(IList<string> request)
    {
        return request.Count < 4 || !request[CommandIndex].Equals(KeyWord, StringComparison.InvariantCultureIgnoreCase)
            ? Next?.Handle(request) ?? new HandlerResult.Fail()
            : new HandlerResult.Success(new FileCopy(request[InitPathIndex], request[FinalPathIndex]));
    }
}