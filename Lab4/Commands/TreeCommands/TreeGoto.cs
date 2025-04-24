using Lab4.States;

namespace Lab4.Commands.TreeCommands;

public class TreeGoto(string path) : ICommand
{
    private string Path { get; set; } = path;

    public OperationResult Execute(Context context)
    {
        if (!context.FileSystem.IsPathRooted(Path))
        {
            Path = context.FileSystem.Combine(context.CurrentAbsolutePath, Path);
        }

        if (!context.FileSystem.DirectoryExists(Path)) return new OperationResult.Fail("directory doesn't exist");
        context.GotoAction(Path);
        return new OperationResult.Success();
    }
}