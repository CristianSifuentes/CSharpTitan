// Concrete class implementing the Logic

public class SameDifferenceChecker<T> : DifferenceCheckerBase<T> where T : struct
{
    public override bool IsConsistent(IReadOnlyList<T>? numbers)
    {
        throw new NotImplementedException();
    }

    private static IEnumerable<T> GetDifferences(IReadOnlyList<T>? numbers)
    {
        throw new NotImplementedException();
    }
} 