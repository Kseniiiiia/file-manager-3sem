using Lab4.Commands.TreeCommands;

namespace Lab4.ResponsibilityChain.Tree;

public class TreeGotoHandler : BaseHandler
{
    private const string KeyWord = "goto";
    private const int CommandIndex = 1;
    private const int PathIndex = 2;

    public override HandlerResult Handle(IList<string> request)
    {
        return request.Count < 3 || !request[CommandIndex].Equals(KeyWord, StringComparison.InvariantCultureIgnoreCase)
            ? Next?.Handle(request) ?? new HandlerResult.Fail()
            : new HandlerResult.Success(new TreeGoto(request[PathIndex]));
    }
}