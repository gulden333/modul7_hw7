namespace spp_pr7.Command;

public class LightOnCommand : ICommand
{
    private Light light;

    public LightOnCommand(Light light)
    {
        this.light = light;
    }

    public void Execute()
    {
        light.TurnOn();
    }

    public void Undo()
    {
        light.TurnOff();
    }

    public string GetDescription()
    {
        return $"Включить свет в {light.Location}";
    }
}
