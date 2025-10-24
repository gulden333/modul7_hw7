namespace spp_pr7.Command;

public class TemperatureIncreaseCommand : ICommand
{
    private Thermostat thermostat;
    private int previousTemperature;

    public TemperatureIncreaseCommand(Thermostat thermostat)
    {
        this.thermostat = thermostat;
    }

    public void Execute()
    {
        previousTemperature = thermostat.Temperature;
        thermostat.IncreaseTemperature();
    }

    public void Undo()
    {
        thermostat.SetTemperature(previousTemperature);
    }

    public string GetDescription()
    {
        return $"Увеличить температуру в {thermostat.Location}";
    }
}