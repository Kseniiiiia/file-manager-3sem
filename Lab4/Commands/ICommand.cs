using Lab4.States;

namespace Lab4.Commands;

public interface ICommand
{
    public OperationResult Execute(Context context);
}