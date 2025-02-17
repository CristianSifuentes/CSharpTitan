//Interface defining the contract for a difference calculator
public interface IDifferenceCalculator<T> {
    
    bool IsConsistent(IReadOnlyList<T>? numbers);
    
    // Event triggered when the difference is calculated
    event Action<string>? OnDifferenceChecked;
    
    // Default method in interface (C# 8.0 and later)
    bool  Validate(IReadOnlyList<T>? numbers) => numbers?.Count > 1;

}