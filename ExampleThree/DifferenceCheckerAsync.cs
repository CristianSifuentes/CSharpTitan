// Async Stream Example
public static class DifferenceCheckerAsync{
    public static async IAsyncEnumerable<bool> CheckAsync<T>(IEnumerable<IReadOnlyList<T>> testCases) where T : struct, System.Numerics.INumber<T>{
        foreach (var testCase in testCases){
            yield return await Task.Run(() => new SameDifferenceChecker<T>().IsConsistent(testCase));
        }
    }

    public static async IAsyncEnumerable<bool> CheckAsync2<T>(IEnumerable<IReadOnlyList<T>> testCases) where T : struct, System.Numerics.INumber<T>{
        var checker = new SameDifferenceChecker<T>();
        
        foreach (var testCase in testCases)
        {
            await Task.Delay(100); // Simulating async operation
            yield return checker.IsConsistent(testCase);
        }
    }
    
 
}