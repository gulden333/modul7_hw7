namespace spp_pr7.Command;

public class Light
{
    private string location;
    private bool isOn = false;

    public Light(string location)
    {
        this.location = location;
    }

    public void TurnOn()
    {
        isOn = true;
        Console.WriteLine($"{location} свет включен");
    }

    public void TurnOff()
    {
        isOn = false;
        Console.WriteLine($"{location} свет выключен");
    }

    public bool IsOn => isOn;
    public string Location => location;
}
