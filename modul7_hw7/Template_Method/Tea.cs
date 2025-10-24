namespace spp_pr7.Template_Method;

public class Tea : Beverage
{
    protected override void Brew()
    {
        Console.WriteLine("Заваривание чая");
    }
    
    protected override void AddCondiments()
    {
        Console.WriteLine("Добавление лимона");
    }
    
    protected override bool CustomerWantsCondiments()
    {
        return GetUserInput("Добавить лимон в чай? (y/n): ");
    }
}

