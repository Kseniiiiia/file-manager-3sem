namespace Lab4.States;

public class ConnectedState(Context context) : IStateHandler
{
    public StateResult Connect(string absolutePath, string mode)
    {
        if (context.ContextState == State.Connect)
        {
            return new StateResult.Invalid("you are already connected");
        }

        context.SetState(new ConnectedState(context));
        context.Mode = mode;
        context.ContextState = State.Connect;
        context.CurrentAbsolutePath = absolutePath;
        return new StateResult.Success(this);
    }

    public StateResult Disconnect()
    {
        context.SetState(new DisconnectedState(context));
        context.Mode = null;
        context.ContextState = State.Disconnect;
        context.CurrentAbsolutePath = string.Empty;
        return new StateResult.Success(new DisconnectedState(context));
    }

    public void GotoAction(string path)
    {
        context.CurrentAbsolutePath = context.FileSystem.IsPathRooted(path) ? path :
            context.FileSystem.Combine(context.CurrentAbsolutePath, path);
    }
}
