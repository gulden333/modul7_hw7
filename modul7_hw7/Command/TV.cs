namespace spp_pr7.Command;

public class TV
{
    private string location;
    private bool isOn = false;
    private int volume = 50;

    public TV(string location)
    {
        this.location = location;
    }

    public void TurnOn()
    {
        isOn = true;
        Console.WriteLine($"{location} телевизор включен, громкость: {volume}%");
    }

    public void TurnOff()
    {
        isOn = false;
        Console.WriteLine($"{location} телевизор выключен");
    }

    public void SetVolume(int vol)
    {
        volume = Math.Max(0, Math.Min(100, vol));
        Console.WriteLine($"{location} телевизор: громкость установлена на {volume}%");
    }

    public bool IsOn => isOn;
    public int Volume => volume;
    public string Location => location;
}
