namespace spp_pr7.Command;

public class SecuritySystem
{
    private string location;
    private bool isArmed = false;

    public SecuritySystem(string location)
    {
        this.location = location;
    }

    public void Arm()
    {
        isArmed = true;
        Console.WriteLine($"{location} сигнализация активирована");
    }

    public void Disarm()
    {
        isArmed = false;
        Console.WriteLine($"{location} сигнализация деактивирована");
    }

    public bool IsArmed => isArmed;
    public string Location => location;
}
