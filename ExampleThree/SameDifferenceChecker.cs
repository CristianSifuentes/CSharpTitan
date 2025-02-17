// Concrete class implementing the Logic
public class SameDifferenceChecker<T> : DifferenceCheckerBase<T> where T : struct{
    public override bool IsConsistent(IReadOnlyList<T>? numbers)
    {
        // if(!Validate(numbers)) return false;
        if (!((IDifferenceCalculator<T>)this).Validate(numbers)) return false;
        
        var differences = GetDifferences(numbers).ToList();
        bool isConsistent = differences.Distinct().Count() == 1;

        // Notify(isConsistent ? "Consistent" : "Inconsistent");
        Notify($"Checked Sequence: {string.Join(", ", numbers ?? new List<T>())}. Result: {isConsistent}");
        return isConsistent;
    }

    private static IEnumerable<T> GetDifferences(IReadOnlyList<T>? numbers)
    {
        throw new NotImplementedException();
    }

} 