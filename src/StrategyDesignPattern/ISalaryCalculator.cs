using StrategyDesignPattern.Models;

namespace StrategyDesignPattern;

public interface ISalaryCalculator
{
    double CalculateTotalSalary(IEnumerable<DeveloperReport> reports);
}