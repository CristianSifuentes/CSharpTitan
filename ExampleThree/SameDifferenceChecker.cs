// Concrete class implementing the Logic
using System.Numerics;

public class SameDifferenceChecker<T> : DifferenceCheckerBase<T> where T : struct, INumber<T>{

    /// <summary>
    /// Check if the numbers in the sequence have the same difference
    /// </summary>
    /// <param name="numbers"></param>
    /// <returns></returns>
    public override bool IsConsistent(IReadOnlyList<T>? numbers){
        // if(!Validate(numbers)) return false;
        if (!((IDifferenceCalculator<T>)this).Validate(numbers)) return false;
        
        var differences = GetDifferences(numbers).ToList();
        bool isConsistent = differences.Distinct().Count() == 1;

        // Notify(isConsistent ? "Consistent" : "Inconsistent");
        Notify($"Checked Sequence: {string.Join(", ", numbers ?? new List<T>())}. Result: {isConsistent}");
        return isConsistent;
    }

    /// <summary>
    /// Get the differences between the numbers in the sequence
    /// </summary>
    /// <param name="numbers"></param>
    /// <returns></returns>
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
            // convert a method in a iterator block to a method that returns a list
            // return differences.ToList();

      }
    }
    


    // private static IEnumerable<double> GetDifferencesList(IReadOnlyList<T>? numbers)
    // {
    //     if (numbers is null || numbers.Count < 2) return new List<double>();

    //     double? firstDiff = null;
    //     List<double> differences = new();
        
    //     for (int i = 1; i < numbers.Count; i++)
    //     {
    //         double diff = numbers[i].ToDouble(null) - numbers[i - 1].ToDouble(null);

    //         if (firstDiff is null) firstDiff = diff;
    //         differences.Add(diff);
    //     }

    //     return differences;
    // }

    
} 