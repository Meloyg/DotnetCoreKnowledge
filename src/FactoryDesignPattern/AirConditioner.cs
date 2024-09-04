using FactoryDesignPattern.Factory;
using FactoryDesignPattern.Models;

namespace FactoryDesignPattern;

public class AirConditioner
{
    private readonly Dictionary<Actions, AirConditionerFactory> _factories;

    public AirConditioner()
    {
        _factories = new Dictionary<Actions, AirConditionerFactory>();

        foreach (Actions action in Enum.GetValues(typeof(Actions)))
        {
            var factory =
                (AirConditionerFactory)Activator.CreateInstance(
                    Type.GetType("FactoryDesignPattern.Factory." + Enum.GetName(typeof(Actions), action) + "Factory"));

            _factories.Add(action, factory);
        }
    }

    public IAirConditioner ExecuteCreation(Actions action, double temperature)
    {
        return _factories[action].Create(temperature);
    }
}