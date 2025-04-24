using Lab4.States;

namespace Lab4.Commands.FileCommands;

public class FileDelete(string filePath) : ICommand
{
    private string FilePath { get; set; } = filePath;

    public OperationResult Execute(Context context)
    {
        if (context.FileSystem.IsPathRooted(FilePath) == false)
        {
            FilePath = context.FileSystem.Combine(context.CurrentAbsolutePath, FilePath);
        }

        return context.FileSystem.DeleteFile(FilePath);
    }
}