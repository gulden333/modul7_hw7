namespace spp_pr7.Command;

public class LightOffCommand : ICommand
{
    private Light light;

    public LightOffCommand(Light light)
    {
        this.light = light;
    }

    public void Execute()
    {
        light.TurnOff();
    }

    public void Undo()
    {
        light.TurnOn();
    }

    public string GetDescription()
    {
        return $"Выключить свет в {light.Location}";
    }
}
