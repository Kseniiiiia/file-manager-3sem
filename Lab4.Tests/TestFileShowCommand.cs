using Lab4.ResponsibilityChain;

using Xunit;

namespace Lab4.Tests;

public class TestFileShowCommand
{
    [Fact]
    public void FileShow_ShouldShowWithAbsPath_Success()
    {
        string requestString = "file show C:\\Users\\rusla\\TestDirectory\\1\\1.txt";
        BaseHandler chain = new CreateResponsibilityChain().CreateChain();
        IList<string> request = requestString.Split();
        HandlerResult result = chain.Handle(request);

        Assert.IsType<HandlerResult.Success>(result);
    }

    [Fact]
    public void FileShow_ShouldNotBeShowWithNoPath_Failure()
    {
        string requestString = "file show";
        BaseHandler chain = new CreateResponsibilityChain().CreateChain();
        IList<string> request = requestString.Split();
        HandlerResult result = chain.Handle(request);

        Assert.IsType<HandlerResult.Fail>(result);
    }

    [Fact]
    public void FileShow_ShouldShowWithMode_Success()
    {
        string requestString = "file show C:\\Users\\rusla\\TestDirectory\\1\\1.txt -m console";
        BaseHandler chain = new CreateResponsibilityChain().CreateChain();
        IList<string> request = requestString.Split();
        HandlerResult result = chain.Handle(request);

        Assert.IsType<HandlerResult.Success>(result);
    }

    [Fact]
    public void FileShow_ShouldShowWithUnknownMode_Failure()
    {
        string requestString = "file show C:\\Users\\rusla\\TestDirectory\\1\\1.txt -m abcdef";
        BaseHandler chain = new CreateResponsibilityChain().CreateChain();
        IList<string> request = requestString.Split();
        HandlerResult result = chain.Handle(request);

        Assert.IsType<HandlerResult.Fail>(result);
    }
}