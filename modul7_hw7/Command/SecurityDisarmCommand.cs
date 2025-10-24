namespace spp_pr7.Command;

public class SecurityDisarmCommand : ICommand
{
    private SecuritySystem security;

    public SecurityDisarmCommand(SecuritySystem security)
    {
        this.security = security;
    }

    public void Execute()
    {
        security.Disarm();
    }

    public void Undo()
    {
        security.Arm();
    }

    public string GetDescription()
    {
        return $"Деактивировать сигнализацию в {security.Location}";
    }
}
