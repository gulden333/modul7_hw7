namespace spp_pr7.Command;

public class TemperatureDecreaseCommand : ICommand
{
    private Thermostat thermostat;
    private int previousTemperature;

    public TemperatureDecreaseCommand(Thermostat thermostat)
    {
        this.thermostat = thermostat;
    }

    public void Execute()
    {
        previousTemperature = thermostat.Temperature;
        thermostat.DecreaseTemperature();
    }

    public void Undo()
    {
        thermostat.SetTemperature(previousTemperature);
    }

    public string GetDescription()
    {
        return $"Уменьшить температуру в {thermostat.Location}";
    }
}