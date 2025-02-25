class Program {
    static void Main(){
        var calculator = new GreatestDifferenceCalculator();
        
        // Subscribing to the event
        calculator.OnDifferenceCalculated += diff => Console.WriteLine($"[Event Triggered] The greatest difference is {diff}");
        
        // Test cases
        var testCases = new List<int[]>{
            new int[]{1, 1, 4},
            new int[]{9, 8},
            new int[]{6, 22, 16, 29, 23},
            new int[]{28, 16, 28, 11, 14, 26, 23, 25, 17, 3, 22, 23, 23, 10}
        };
        // foreach(var testCase in testCases){
        //     Console.WriteLine($"The greatest difference in {string.Join(", ", testCase)} is {calculator.CalculateDifference(testCase)}");
        // }

        foreach(var testCase in testCases){
            int result = calculator.CalculateDifference(testCase);
            var calculation = new CalculationResult(testCase.Min(),  testCase.Max(), result);
            Console.WriteLine(calculation);
            Console.WriteLine("---");
        }

        // NumberOperation operation = CheckConditions.SumNumbers;
        // int result2 = operation([1, 2, 3, 4, 5]);   
        // Console.WriteLine($"The greatest difference is {result2}");
    
    }
}