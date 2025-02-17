
// Delegate for custom number operations
public delegate int NumberOperation(IReadOnlyList<int> numbers);

// Base class enforcing a contract
public abstract class DifferenceCalculatorBase {
    
    //Event triggered when the difference is calculated
    public event Action<int>? OnDifferenceCalculated;
    
    // Abstract method to be implemented
    public abstract int CalculateDifference(IReadOnlyList<int> numbers);
    

    // Method to trigger the event
    protected void TriggerDifferenceCalculated(int difference){
        OnDifferenceCalculated?.Invoke(difference);
    }

    // protected void TriggerDifferenceCalculated(int difference) => OnDifferenceCalculated?.Invoke(difference);


}