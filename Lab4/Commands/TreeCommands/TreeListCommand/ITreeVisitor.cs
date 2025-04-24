using Lab4.States;

namespace Lab4.Commands.TreeCommands.TreeListCommand;

public interface ITreeVisitor
{
    void VisitDirectory(string? path, string currentIndent, Context context);

    void VisitFile(string? path, Context context, string currentIndent);
}