using Lab4.Commands.FileCommands;

namespace Lab4.ResponsibilityChain.File;

public class FileRenameHandler : BaseHandler
{
    private const string KeyWord = "rename";
    private const int CommandIndex = 1;
    private const int InitPathIndex = 2;
    private const int NewNameIndex = 3;

    public override HandlerResult Handle(IList<string> request)
    {
        return request.Count < 4 || !request[CommandIndex].Equals(KeyWord, StringComparison.InvariantCultureIgnoreCase)
            ? Next?.Handle(request) ?? new HandlerResult.Fail()
            : new HandlerResult.Success(new FileRename(request[NewNameIndex], request[InitPathIndex]));
    }
}