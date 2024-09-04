namespace FactoryDesignPattern;

public class WarmingManager(double temperature) : IAirConditioner
{
    public void Operate()
    {
        Console.WriteLine($"Warming to the desired temperature of {temperature}°C");
    }
}