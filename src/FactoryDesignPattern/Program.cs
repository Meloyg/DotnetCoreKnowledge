using FactoryDesignPattern;
using FactoryDesignPattern.Models;

var factory = new AirConditioner().ExecuteCreation(Actions.Warming, 25);

factory.Operate();