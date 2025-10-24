namespace spp_pr7.Command;

public class Door
{
    private string location;
    private bool isOpen = false;

    public Door(string location)
    {
        this.location = location;
    }

    public void Open()
    {
        isOpen = true;
        Console.WriteLine($"{location} дверь открыта");
    }

    public void Close()
    {
        isOpen = false;
        Console.WriteLine($"{location} дверь закрыта");
    }

    public bool IsOpen => isOpen;
    public string Location => location;
}
