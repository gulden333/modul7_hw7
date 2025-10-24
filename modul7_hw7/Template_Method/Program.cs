namespace spp_pr7.Template_Method;
using System;

class Program
{
    static void Main(string[] args)
    {
        Beverage tea = new Tea();
        Beverage coffee = new Coffee();
        Beverage hotChocolate = new HotChocolate();
        
        Console.WriteLine("приготовление чая:");
        tea.PrepareRecipe();
        
        Console.WriteLine("\nприготовление кофе:");
        coffee.PrepareRecipe();
        
        Console.WriteLine("\nприготовление горячего шоколада:");
        hotChocolate.PrepareRecipe();
    }
}
