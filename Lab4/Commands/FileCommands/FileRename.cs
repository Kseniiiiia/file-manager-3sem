using Lab4.States;

namespace Lab4.Commands.FileCommands;

public class FileRename(string fileName, string filePath) : ICommand
{
    private string FileName { get; set; } = fileName;

    private string FilePath { get; set; } = filePath;

    public OperationResult Execute(Context context)
    {
        if (context.FileSystem.IsPathRooted(FilePath) == false)
        {
            FilePath = context.FileSystem.Combine(context.CurrentAbsolutePath, FilePath);
        }

        return context.FileSystem.RenameFile(FilePath, FileName);
    }
}