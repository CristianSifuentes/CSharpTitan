// Concrete class implementing the Logic

public class GreatestDifferenceCalculator : DifferenceCalculatorBase
{
    public override int CalculateDifference(IReadOnlyList<int> numbers)
    {
        // Edge case: If the collection is empty, return 0
        if(numbers?.Any() != true) return 0;

        int min = numbers.Min();
        int max = numbers.Max();
        int difference = max - min;
        TriggerDifferenceCalculated(difference);
        return difference;
    }
}