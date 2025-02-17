// Abstract base class for difference calculation

public abstract class DifferenceCheckerBase<T>: IDifferenceCalculator<T> where T : struct {
    
    // Event triggered when the difference is calculated
    public event Action<string>? OnDifferenceChecked;

    public abstract bool IsConsistent(IReadOnlyList<T>? numbers);
    
    protected void Notify(string message){
        OnDifferenceChecked?.Invoke(message);
    }
}