using Lab4.ResponsibilityChain;

using Xunit;

namespace Lab4.Tests;

public class TestFileCopyCommand
{
    [Fact]
    public void FileCopy_ShouldCopy_Success()
    {
        string requestString = "file copy C:\\Users\\rusla\\TestDirectory\\1\\1.txt C:\\Users\\rusla\\TestDirectory\\2";
        BaseHandler chain = new CreateResponsibilityChain().CreateChain();
        IList<string> request = requestString.Split();
        HandlerResult result = chain.Handle(request);

        Assert.IsType<HandlerResult.Success>(result);
    }
}