using Lab4.ResponsibilityChain;

using Xunit;

namespace Lab4.Tests;

public class TestDisconnectCommand
{
    [Fact]
    public void Disconnect_ShouldDisconnect_Success()
    {
        string requestString = "disconnect";
        BaseHandler chain = new CreateResponsibilityChain().CreateChain();
        IList<string> request = requestString.Split();
        HandlerResult result = chain.Handle(request);

        Assert.IsType<HandlerResult.Success>(result);
    }
}