using Lab4.Commands.FileCommands;

namespace Lab4.ResponsibilityChain.File;

public class FileMoveHandler : BaseHandler
{
    private const string KeyWord = "move";
    private const int CommandIndex = 1;
    private const int InitPathIndex = 2;
    private const int FinalPathIndex = 3;

    public override HandlerResult Handle(IList<string> request)
    {
        return request.Count < 4 || !request[CommandIndex].Equals(KeyWord, StringComparison.InvariantCultureIgnoreCase)
            ? Next?.Handle(request) ?? new HandlerResult.Fail()
            : new HandlerResult.Success(new FileMove(request[InitPathIndex], request[FinalPathIndex]));
    }
}