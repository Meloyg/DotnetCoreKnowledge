using FactoryDesignPattern;
using FactoryDesignPattern.Models;

AirConditioner
    .Initialize()
    .ExecuteCreation(Actions.Warming, 25)
    .Operate();