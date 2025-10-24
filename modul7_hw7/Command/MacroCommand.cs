namespace spp_pr7.Command;

public class MacroCommand : ICommand
{
    private List<ICommand> commands;
    private string description;

    public MacroCommand(List<ICommand> commands, string description)
    {
        this.commands = commands;
        this.description = description;
    }

    public void Execute()
    {
        Console.WriteLine($"Выполнение макрокоманды: {description}");
        foreach (var command in commands)
        {
            command.Execute();
        }
    }

    public void Undo()
    {
        Console.WriteLine($"Отмена макрокоманды: {description}");
        for (int i = commands.Count - 1; i >= 0; i--)
        {
            commands[i].Undo();
        }
    }

    public string GetDescription()
    {
        return description;
    }
}