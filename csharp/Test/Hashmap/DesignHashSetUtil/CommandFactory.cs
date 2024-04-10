using System;

namespace Test.Hashmap.DesignHashSetUtil;
internal static class CommandFactory
{
    public static ICommand CreateCommand(string commandName)
    {
        switch (commandName)
        {
            case "add":
                return new AddCommand();
            case "remove":
                return new RemoveCommand();
            case "contains":
                return new ContainsCommand();
            default:
                throw new ArgumentException($"Unknown command: {commandName}");
        }
    }
}
