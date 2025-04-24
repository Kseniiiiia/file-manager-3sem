using Lab4.ResponsibilityChain;

using Xunit;

namespace Lab4.Tests;

public class TestConnectCommand
{
    [Fact]
    public void Connect_ShouldConnectWithAbsPath_Success()
    {
        string requestString = "connect C:\\Users\\rusla";
        BaseHandler chain = new CreateResponsibilityChain().CreateChain();
        IList<string> request = requestString.Split();
        HandlerResult result = chain.Handle(request);

        Assert.IsType<HandlerResult.Success>(result);
    }

    [Fact]
    public void Connect_ShouldNotBeConnectWithNoPath_Failure()
    {
        string requestString = "connect";
        BaseHandler chain = new CreateResponsibilityChain().CreateChain();
        IList<string> request = requestString.Split();
        HandlerResult result = chain.Handle(request);

        Assert.IsType<HandlerResult.Fail>(result);
    }

    [Fact]
    public void Connect_ShouldConnectWithMode_Success()
    {
        string requestString = "connect C:\\Users\\rusla -m local";
        BaseHandler chain = new CreateResponsibilityChain().CreateChain();
        IList<string> request = requestString.Split();
        HandlerResult result = chain.Handle(request);

        Assert.IsType<HandlerResult.Success>(result);
    }

    [Fact]
    public void Connect_ShouldConnectWithUnknownMode_Failure()
    {
        string requestString = "connect C:\\Users\\rusla -m abcdef";
        BaseHandler chain = new CreateResponsibilityChain().CreateChain();
        IList<string> request = requestString.Split();
        HandlerResult result = chain.Handle(request);

        Assert.IsType<HandlerResult.Fail>(result);
    }
}