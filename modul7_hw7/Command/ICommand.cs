namespace spp_pr7.Command;

public interface ICommand
{
    void Execute();
    void Undo();
    string GetDescription();
}