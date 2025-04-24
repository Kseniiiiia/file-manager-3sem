using Lab4.Commands.TreeCommands.TreeListCommand;
using Lab4.FileSystem;

namespace Lab4.States;

public class Context
{
    public Context(IFileSystem fileSystem, OutputWrite outputWrite, TreeListSymbols treeListSymbols, ITreeVisitor visitor)
    {
        FileSystem = fileSystem;
        OutputWrite = outputWrite;
        TreeSymbols = treeListSymbols;
        Visitor = visitor;
        Mode = null;
        ContextState = State.Disconnect;
        CurrentAbsolutePath = string.Empty;
        _state = new DisconnectedState(this);
    }

    public string CurrentAbsolutePath { get; set; }

    public TreeListSymbols TreeSymbols { get; set; }

    public IFileSystem FileSystem { get; set; }

    public ITreeVisitor Visitor { get; set; }

    public State ContextState { get; set; }

    public string? Mode { get; set; }

    public OutputWrite OutputWrite { get; private set; }

    private IStateHandler? _state;

    public void SetState(IStateHandler state)
    {
        _state = state;
    }

    public void Connect(string absolutePath, string mode)
    {
        _state?.Connect(absolutePath, mode);
    }

    public void Disconnect()
    {
        _state?.Disconnect();
    }

    public void GotoAction(string path)
    {
        _state?.GotoAction(path);
    }
}
