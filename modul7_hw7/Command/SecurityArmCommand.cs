namespace spp_pr7.Command;

public class SecurityArmCommand : ICommand
{
    private SecuritySystem security;

    public SecurityArmCommand(SecuritySystem security)
    {
        this.security = security;
    }

    public void Execute()
    {
        security.Arm();
    }

    public void Undo()
    {
        security.Disarm();
    }

    public string GetDescription()
    {
        return $"Активировать сигнализацию в {security.Location}";
    }
}
