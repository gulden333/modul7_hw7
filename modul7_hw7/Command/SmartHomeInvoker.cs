namespace spp_pr7.Command;

public class SmartHomeInvoker
{
    private Stack<ICommand> commandHistory;
    private Stack<ICommand> undoneCommands;
    private const int MaxHistorySize = 10;

    public SmartHomeInvoker()
    {
        commandHistory = new Stack<ICommand>();
        undoneCommands = new Stack<ICommand>();
    }

    public void ExecuteCommand(ICommand command)
    {
        try
        {
            command.Execute();
            commandHistory.Push(command);
            
            // Очищаем стек отмененных команд при новом выполнении
            undoneCommands.Clear();
            
            // Ограничиваем размер истории
            if (commandHistory.Count > MaxHistorySize)
            {
                var tempStack = new Stack<ICommand>();
                for (int i = 0; i < MaxHistorySize; i++)
                {
                    tempStack.Push(commandHistory.Pop());
                }
                commandHistory = tempStack;
            }
            
            Console.WriteLine($"✓ Выполнено: {command.GetDescription()}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при выполнении команды: {ex.Message}");
        }
    }

    public void UndoLastCommand()
    {
        try
        {
            if (commandHistory.Count == 0)
            {
                throw new InvalidOperationException("Нет команд для отмены");
            }

            var command = commandHistory.Pop();
            command.Undo();
            undoneCommands.Push(command);
            
            Console.WriteLine($"↶ Отменено: {command.GetDescription()}");
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Ошибка отмены: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при отмене команды: {ex.Message}");
        }
    }

    public void RedoLastUndoneCommand()
    {
        try
        {
            if (undoneCommands.Count == 0)
            {
                throw new InvalidOperationException("Нет отмененных команд для повтора");
            }

            var command = undoneCommands.Pop();
            command.Execute();
            commandHistory.Push(command);
            
            Console.WriteLine($"↷ Повторено: {command.GetDescription()}");
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Ошибка повтора: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при повторе команды: {ex.Message}");
        }
    }

    public void ShowCommandHistory()
    {
        Console.WriteLine("\n--- История команд ---");
        if (commandHistory.Count == 0)
        {
            Console.WriteLine("История пуста");
            return;
        }

        int index = 1;
        foreach (var command in commandHistory.Reverse())
        {
            Console.WriteLine($"{index}. {command.GetDescription()}");
            index++;
        }
    }

    public void ShowUndoneCommands()
    {
        Console.WriteLine("\n--- Отмененные команды ---");
        if (undoneCommands.Count == 0)
        {
            Console.WriteLine("Нет отмененных команд");
            return;
        }

        int index = 1;
        foreach (var command in undoneCommands.Reverse())
        {
            Console.WriteLine($"{index}. {command.GetDescription()}");
            index++;
        }
    }
}
