using Lab4.States;

namespace Lab4.Commands;

public class Disconnect : ICommand
{
    public OperationResult Execute(Context context)
    {
        context.Disconnect();
        return new OperationResult.Success();
    }
}