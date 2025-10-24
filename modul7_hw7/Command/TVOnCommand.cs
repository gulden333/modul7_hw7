namespace spp_pr7.Command;

public class TVOnCommand : ICommand
{
    private TV tv;
    private int previousVolume;

    public TVOnCommand(TV tv)
    {
        this.tv = tv;
    }

    public void Execute()
    {
        previousVolume = tv.Volume;
        tv.TurnOn();
    }

    public void Undo()
    {
        tv.TurnOff();
    }

    public string GetDescription()
    {
        return $"Включить телевизор в {tv.Location}";
    }
}