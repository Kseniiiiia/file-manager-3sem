using Lab4.States;

namespace Lab4.Commands;

public class Connect(string absolutePath, string mode) : ICommand
{
    private string AbsolutePath { get; set; } = absolutePath;

    private string Mode { get; set; } = mode;

    public OperationResult Execute(Context context)
    {
        if (!context.FileSystem.DirectoryExists(AbsolutePath))
            return new OperationResult.Fail("directory was not found");
        context.Connect(AbsolutePath, Mode);

        return new OperationResult.Success();
    }
}