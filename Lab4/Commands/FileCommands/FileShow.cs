using Lab4.States;

namespace Lab4.Commands.FileCommands;

public class FileShow(string filePath, string? mode) : ICommand
{
    private const string ConsoleMode = "console";

    private string? Mode { get; set; } = mode;

    private string FilePath { get; set; } = filePath;

    public OperationResult Execute(Context context)
    {
        if (!string.IsNullOrEmpty(Mode) && Mode != ConsoleMode)
        {
            return new OperationResult.Fail("unknown file show mode");
        }

        if (context.FileSystem.IsPathRooted(FilePath) == false)
        {
            FilePath = context.FileSystem.Combine(context.CurrentAbsolutePath, FilePath);
        }

        string? content = context.FileSystem.ShowFile(FilePath);

        if (content is null) return new OperationResult.Fail("file not found");
        context.OutputWrite.Output(content);
        return new OperationResult.Success();
    }
}