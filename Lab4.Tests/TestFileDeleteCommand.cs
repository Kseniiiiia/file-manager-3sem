using Lab4.ResponsibilityChain;

using Xunit;

namespace Lab4.Tests;

public class TestFileDeleteCommand
{
    [Fact]
    public void FileDelete_ShouldDelete_Success()
    {
        string requestString = "file delete C:\\Users\\rusla\\TestDirectory\\1\\del.txt";
        BaseHandler chain = new CreateResponsibilityChain().CreateChain();
        IList<string> request = requestString.Split();
        HandlerResult result = chain.Handle(request);

        Assert.IsType<HandlerResult.Success>(result);
    }
}