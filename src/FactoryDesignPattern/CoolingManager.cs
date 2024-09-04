namespace FactoryDesignPattern;

public class CoolingManager(double temperature) : IAirConditioner
{
    public void Operate()
    {
        Console.WriteLine($"Cooling to the desired temperature of {temperature}°C");
    }
}   