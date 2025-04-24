using Lab4.ResponsibilityChain;

using Xunit;

namespace Lab4.Tests;

public class TestFileRenameCommand
{
    [Fact]
    public void FileRename_ShouldRename_Success()
    {
        string requestString = "file rename C:\\Users\\rusla\\TestDirectory\\1\\1.txt file1.txt";
        BaseHandler chain = new CreateResponsibilityChain().CreateChain();
        IList<string> request = requestString.Split();
        HandlerResult result = chain.Handle(request);

        Assert.IsType<HandlerResult.Success>(result);
    }
}