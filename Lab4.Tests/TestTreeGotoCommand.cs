using Lab4.ResponsibilityChain;

using Xunit;

namespace Lab4.Tests;

public class TestTreeGotoCommand
{
    [Fact]
    public void TreeGoto_ShouldTreeGoto_Success()
    {
        string requestString = "tree goto C:\\Users\\rusla\\TestDirectory";
        BaseHandler chain = new CreateResponsibilityChain().CreateChain();
        IList<string> request = requestString.Split();
        HandlerResult result = chain.Handle(request);

        Assert.IsType<HandlerResult.Success>(result);
    }
}