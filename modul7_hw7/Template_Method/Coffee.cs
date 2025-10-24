namespace spp_pr7.Template_Method;

public class Coffee : Beverage
{
    protected override void Brew()
    {
        Console.WriteLine("заваривание кофе");
    }
    
    protected override void AddCondiments()
    {
        Console.WriteLine("добавление сахара и молока");
    }
    
    protected override bool CustomerWantsCondiments()
    {
        return GetUserInput("добавить сахар и молоко в кофе? (y/n): ");
    }
}
