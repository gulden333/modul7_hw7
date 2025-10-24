namespace spp_pr7.Command;

public class Thermostat
{
    private string location;
    private int temperature = 22;
    private const int MinTemp = 16;
    private const int MaxTemp = 30;

    public Thermostat(string location)
    {
        this.location = location;
    }

    public void IncreaseTemperature()
    {
        if (temperature < MaxTemp)
        {
            temperature++;
            Console.WriteLine($"{location} термостат: температура увеличена до {temperature}°C");
        }
        else
        {
            Console.WriteLine($"{location} термостат: максимальная температура достигнута ({temperature}°C)");
        }
    }

    public void DecreaseTemperature()
    {
        if (temperature > MinTemp)
        {
            temperature--;
            Console.WriteLine($"{location} термостат: температура уменьшена до {temperature}°C");
        }
        else
        {
            Console.WriteLine($"{location} термостат: минимальная температура достигнута ({temperature}°C)");
        }
    }

    public void SetTemperature(int temp)
    {
        if (temp >= MinTemp && temp <= MaxTemp)
        {
            temperature = temp;
            Console.WriteLine($"{location} термостат: температура установлена на {temperature}°C");
        }
        else
        {
            Console.WriteLine($"{location} термостат: температура должна быть между {MinTemp} и {MaxTemp}°C");
        }
    }

    public int Temperature => temperature;
    public string Location => location;
}