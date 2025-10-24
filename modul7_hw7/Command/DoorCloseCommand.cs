namespace spp_pr7.Command;

public class DoorCloseCommand : ICommand
{
    private Door door;

    public DoorCloseCommand(Door door)
    {
        this.door = door;
    }

    public void Execute()
    {
        door.Close();
    }

    public void Undo()
    {
        door.Open();
    }

    public string GetDescription()
    {
        return $"Закрыть дверь в {door.Location}";
    }
}
