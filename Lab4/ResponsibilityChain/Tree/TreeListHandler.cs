using Lab4.Commands.TreeCommands.TreeListCommand;

namespace Lab4.ResponsibilityChain.Tree;

public class TreeListHandler : BaseHandler
{
    private const string KeyWord = "list";
    private const string DepthKey = "-d";
    private const int CommandIndex = 1;

    public override HandlerResult Handle(IList<string> request)
    {
        if (request.Count < 2 || !request[CommandIndex].Equals(KeyWord, StringComparison.InvariantCultureIgnoreCase))
        {
            return Next?.Handle(request) ?? new HandlerResult.Fail();
        }

        int depthIndex = request.IndexOf(DepthKey);
        return depthIndex > 0
            ? int.TryParse(request[depthIndex + 1], out int depth)
                ? new HandlerResult.Success(new TreeList(depth))
                : new HandlerResult.Fail()
            : new HandlerResult.Success(new TreeList(1));
    }
}