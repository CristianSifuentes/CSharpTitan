// Example usage: dotnet run --project ExampleOne
class Program {
    static void Main() {
       //CheckConditions checkConditions = new CheckConditions();
       //Cannot create an instance of the static class 'CheckConditions'
       List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 1 };
       // Argument 1: cannot convert from 'method group' to 'CheckCondition<int>'CS1503
       // first way to create a NumberChecker
       CheckCondition<int> condition = CheckConditions.CountOccurrences;   
       NumberChecker<int> checker = new NumberChecker<int>(condition);
       
       Console.WriteLine(checker.Contains(numbers, 4, 2)); 
       Console.WriteLine(checker.Contains(numbers, 5, 2)); 
       Console.WriteLine(checker.Contains(numbers, 1, 2)); 

       // Another way to create a NumberChecker
       //NumberChecker<int> checker = new NumberChecker<int>(CheckConditions.CountOccurrences);

       EventDrivenChecker<int> eventDrivenChecker = new (CheckConditions.CountOccurrences);
       eventDrivenChecker.OnConditionChecked += (message) => Console.WriteLine(message);
       Console.WriteLine(eventDrivenChecker.Contains(numbers, 1, 2));

    }

}