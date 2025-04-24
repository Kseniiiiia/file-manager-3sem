using Lab4.States;

namespace Lab4.Commands.FileCommands;

public class FileMove(string initPath, string finalPath) : ICommand
{
    private string InitPath { get; set; } = initPath;

    private string FinalPath { get; set; } = finalPath;

    public OperationResult Execute(Context context)
    {
        if (context.FileSystem.IsPathRooted(InitPath) == false)
        {
            InitPath = context.FileSystem.Combine(context.CurrentAbsolutePath, InitPath);
        }

        if (context.FileSystem.IsPathRooted(FinalPath) == false)
        {
            FinalPath = context.FileSystem.Combine(context.CurrentAbsolutePath, FinalPath);
        }

        return context.FileSystem.MoveFile(InitPath, FinalPath);
    }
}