// Async Stream Example
public static class DifferenceCheckerAsync{
    public static async IAsyncEnumerable<bool> CheckAsync<T>(IEnumerable<IReadOnlyList<T>> testCases) where T : struct{
        foreach (var testCase in testCases){
            yield return await Task.Run(() => new SameDifferenceChecker<T>().IsConsistent(testCase));
        }
    }
 
}