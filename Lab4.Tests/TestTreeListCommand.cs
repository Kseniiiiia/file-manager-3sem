using Lab4.ResponsibilityChain;

using Xunit;

namespace Lab4.Tests;

public class TestTreeListCommand
{
    [Fact]
    public void TreeList_ShoulList_Success()
    {
        string requestString = "tree list";
        BaseHandler chain = new CreateResponsibilityChain().CreateChain();
        IList<string> request = requestString.Split();
        HandlerResult result = chain.Handle(request);

        Assert.IsType<HandlerResult.Success>(result);
    }

    [Fact]
    public void TreeList_ShouldListWithMode_Success()
    {
        string requestString = "tree list -d 2";
        BaseHandler chain = new CreateResponsibilityChain().CreateChain();
        IList<string> request = requestString.Split();
        HandlerResult result = chain.Handle(request);

        Assert.IsType<HandlerResult.Success>(result);
    }
}