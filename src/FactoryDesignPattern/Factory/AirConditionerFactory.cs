namespace FactoryDesignPattern.Factory;

public abstract class AirConditionerFactory
{
    public abstract IAirConditioner Create(double temperature);
}