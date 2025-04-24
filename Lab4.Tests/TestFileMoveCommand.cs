using Lab4.ResponsibilityChain;

using Xunit;

namespace Lab4.Tests;

public class TestFileMoveCommand
{
    [Fact]
    public void FileMove_ShouldMove_Success()
    {
        string requestString = "file move C:\\Users\\rusla\\TestDirectory\\1\\move.txt C:\\Users\\rusla\\TestDirectory\\2\\";
        BaseHandler chain = new CreateResponsibilityChain().CreateChain();
        IList<string> request = requestString.Split();
        HandlerResult result = chain.Handle(request);

        Assert.IsType<HandlerResult.Success>(result);
    }
}