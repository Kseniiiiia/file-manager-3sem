namespace Lab4.States;

public interface IStateHandler
{
    StateResult Disconnect();

    StateResult Connect(string absolutePath, string mode);

    void GotoAction(string path);
}