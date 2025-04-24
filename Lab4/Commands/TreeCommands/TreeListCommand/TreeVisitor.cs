using Lab4.States;

namespace Lab4.Commands.TreeCommands.TreeListCommand;

public class TreeVisitor : ITreeVisitor
{
    public void VisitDirectory(string? path, string currentIndent, Context context)
    {
        string? directoryName = context.FileSystem.GetFileName(path);
        if (directoryName != null)
        {
            Console.WriteLine($"{currentIndent}{context.TreeSymbols.DirectorySymbol} {directoryName}");
        }
    }

    public void VisitFile(string? path, Context context, string? currentIndent)
    {
        string? fileName = context.FileSystem.GetFileName(path);
        if (fileName != null)
        {
            Console.WriteLine($"{currentIndent}{context.TreeSymbols.FileSymbol} {fileName}");
        }
    }
}