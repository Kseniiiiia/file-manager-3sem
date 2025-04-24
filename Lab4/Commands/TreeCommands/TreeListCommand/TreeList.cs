using Lab4.States;

namespace Lab4.Commands.TreeCommands.TreeListCommand;

public class TreeList(int maxDepth) : ICommand
{
    private int MaxDepth { get; } = maxDepth;

    public OperationResult Execute(Context context)
    {
        PrintTree(context.CurrentAbsolutePath, MaxDepth, context, string.Empty);
        return new OperationResult.Success();
    }

    public void PrintTree(string directoryPath, int maxDepth, Context context, string currentIndent)
    {
        if (currentIndent.Length / 4 > maxDepth) return;

        string fullPath = context.FileSystem.GetFullPath(directoryPath);
        context.Visitor.VisitDirectory(fullPath, currentIndent, context);

        if (currentIndent.Length / 4 == maxDepth) return;

        IList<string> subDirectories = context.FileSystem.GetDirectories(directoryPath);
        IList<string> files = context.FileSystem.GetFiles(directoryPath);

        string newIndent = currentIndent + context.TreeSymbols.IndentSymbol;

        foreach (string directory in subDirectories)
        {
            PrintTree(directory, maxDepth, context, newIndent);
        }

        foreach (string file in files)
        {
            context.Visitor.VisitFile(file, context, newIndent);
        }
    }
}