namespace spp_pr7.Template_Method;

public class HotChocolate : Beverage
{
    protected override void Brew()
    {
        Console.WriteLine("растворение шоколада");
    }
    
    protected override void AddCondiments()
    {
        Console.WriteLine("добавление зефира");
    }
    
    protected override bool CustomerWantsCondiments()
    {
        return GetUserInput("добавить зефир в горячий шоколад? (y/n): ");
    }
}
