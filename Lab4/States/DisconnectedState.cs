namespace Lab4.States;

public class DisconnectedState(Context context) : IStateHandler
{
    public StateResult Connect(string absolutePath, string mode)
    {
        context.SetState(new ConnectedState(context));
        context.Mode = mode;
        context.ContextState = State.Connect;
        context.CurrentAbsolutePath = absolutePath;
        return new StateResult.Success(new ConnectedState(context));
    }

    public StateResult Disconnect()
    {
        if (context.ContextState == State.Disconnect)
        {
            return new StateResult.Invalid("you are already disconnected");
        }

        context.SetState(new DisconnectedState(context));
        context.Mode = null;
        context.ContextState = State.Disconnect;
        context.CurrentAbsolutePath = string.Empty;
        return new StateResult.Success(this);
    }

    public void GotoAction(string path)
    {
        Console.WriteLine("you are disconnected");
    }
}
