namespace spp_pr7.Template_Method;

public abstract class Beverage
{
    // Шаблонный метод
    public void PrepareRecipe()
    {
        BoilWater();
        Brew();
        PourInCup();
        if (CustomerWantsCondiments())
        {
            AddCondiments();
        }
    }
    
    protected abstract void Brew();
    protected abstract void AddCondiments();
    
    protected void BoilWater()
    {
        Console.WriteLine("кипячение воды");
    }
    
    protected void PourInCup()
    {
        Console.WriteLine("наливание в чашку");
    }
    
    protected bool GetUserInput(string question)
    {
        while (true)
        {
            Console.Write(question);
            string input = Console.ReadLine()?.ToLower().Trim();
            
            if (input == "y" || input == "yes" || input == "д" || input == "да")
            {
                return true;
            }
            else if (input == "n" || input == "no" || input == "н" || input == "нет")
            {
                return false;
            }
            else
            {
                Console.WriteLine("некорректный ввод. пожалуйста, введите 'y' или 'n'");
            }
        }
    }
    
    protected virtual bool CustomerWantsCondiments()
    {
        return GetUserInput("добавить добавки? (y/n): ");
    }
}