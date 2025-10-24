namespace spp_pr7.Command;

public class TVOffCommand : ICommand
{
    private TV tv;

    public TVOffCommand(TV tv)
    {
        this.tv = tv;
    }

    public void Execute()
    {
        tv.TurnOff();
    }

    public void Undo()
    {
        tv.TurnOn();
    }

    public string GetDescription()
    {
        return $"Выключить телевизор в {tv.Location}";
    }
}
