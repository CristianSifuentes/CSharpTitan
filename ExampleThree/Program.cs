// Top-Level Program
class Program
{
    static async Task Main(){
        // The type 'object' must be a non-nullable value type in order to use it as parameter 'T' in the generic type or method 'SameDifferenceChecker<T>'CS0453
        var checker = new SameDifferenceChecker<double>();
        // checker.OnDifferenceChecked += (message) => Console.WriteLine(message);
        checker.OnDifferenceChecked += msg => Console.WriteLine($"[Event Triggered] {msg}");
         
        var testCases = new List<double[]>{
            new double[]{1, 1, 4},
            new double[]{9, 8},
            new double[]{6, 22, 16, 29, 23},
            new double[]{28, 16, 28, 11, 14, 26, 23, 25, 17, 3, 22, 23, 23, 10}
        };

        // foreach(var testCase in testCases){
        //     var result = await checker.CheckAsync(testCase);
        //     await foreach(var item in result){
        //         Console.WriteLine($"The difference is consistent: {item}");
        //     }
        // }

        foreach(var testCase in testCases){
            Console.WriteLine($"Result: {checker.IsConsistent(testCase)}");
            Console.WriteLine("---");
        }

    }

}