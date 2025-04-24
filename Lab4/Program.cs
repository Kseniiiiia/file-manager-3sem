using Lab4.Commands.TreeCommands.TreeListCommand;
using Lab4.FileSystem;
using Lab4.ResponsibilityChain;
using Lab4.States;

namespace Lab4;

public static class Program
{
    public static void Main()
    {
        var localFileSystem = new LocalFileSystem();
        var treeListSymbols = new TreeListSymbols();
        var outputWrite = new OutputWrite();
        var visitor = new TreeVisitor();

        var context = new Context(localFileSystem, outputWrite, treeListSymbols, visitor);

        BaseHandler chain = new CreateResponsibilityChain().CreateChain();
        while (true)
        {
            string? requestString = Console.ReadLine();
            if (requestString is not null && requestString.Equals("Q", StringComparison.InvariantCultureIgnoreCase))
            {
                Console.WriteLine("The program has completed its work");
                break;
            }

            if (requestString is not null)
            {
                {
                    IList<string> request = requestString.Split();
                    HandlerResult result = chain.Handle(request);

                    if (result is HandlerResult.Success success)
                    {
                        OperationResult operationResult = success.Command.Execute(context);

                        if (operationResult is OperationResult.Success)
                        {
                            Console.WriteLine("Command was successfully executed");
                        }
                        else if (operationResult is OperationResult.Fail fail)
                        {
                            Console.WriteLine(fail.ErrorMessage);
                        }
                    }

                    if (result is HandlerResult.Fail)
                    {
                        Console.WriteLine("Unable to process request");
                    }
                }
            }
        }
    }
}