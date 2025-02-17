// Concrete class implementing the Logic
using System.Numerics;

public class SameDifferenceChecker<T> : DifferenceCheckerBase<T> where T : struct, INumber<T>{
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

    private static IEnumerable<T> GetDifferences(IReadOnlyList<T>? numbers){
      if(numbers == null || numbers.Count < 2) yield break;
      
      //Represents an object whose operations will be resolved at runtime.
      dynamic? firstDiff = null;
      for(int i = 1; i < numbers.Count; i++){
            dynamic diff = numbers[i] - numbers[i - 1];
            if(firstDiff == null){
                firstDiff = diff;
            }
            yield return diff;

      }
    }

} 