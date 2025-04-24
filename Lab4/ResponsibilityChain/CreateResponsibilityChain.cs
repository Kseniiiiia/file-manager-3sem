using Lab4.ResponsibilityChain.File;
using Lab4.ResponsibilityChain.Tree;

namespace Lab4.ResponsibilityChain;

public class CreateResponsibilityChain
{
    public BaseHandler CreateChain()
    {
        var firstHandler = new ConnectHandler();

        firstHandler
            .SetNext(new DisconnectHandler())
            .SetNext(new TreeGotoHandler())
            .SetNext(new TreeListHandler())
            .SetNext(new FileShowHandler())
            .SetNext(new FileMoveHandler())
            .SetNext(new FileCopyHandler())
            .SetNext(new FileDeleteHandler())
            .SetNext(new FileRenameHandler());

        return firstHandler;
    }
}