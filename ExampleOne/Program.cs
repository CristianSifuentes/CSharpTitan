using System;
using System.Collections.Generic;
using System.Linq;

// Delegate to define a generic checking condition
public delegate bool CheckCondition<T>(IEnumerable<T> collection, T item, int threshold);

// Example usage
class Program
{
    static void Main(){
        List<int> numbers = new List<int> { 4, 5, 2, 4, 5, 9, 9, 4, 4 };

        // Instantiate checker with the provided condition
        NumberChecker<int> checker = new NumberChecker<int>(CheckConditions.CountOccurrences);

        Console.WriteLine(checker.Contains(numbers, 4, 5)); // False
        Console.WriteLine(checker.Contains(numbers, 4, 4)); // True
        Console.WriteLine(checker.Contains(numbers, 4, 3)); // True
        Console.WriteLine(checker.Contains(numbers, 9, 2)); // True
    }
}