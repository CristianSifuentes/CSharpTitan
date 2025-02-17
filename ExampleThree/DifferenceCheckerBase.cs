// Abstract base class for difference calculation

public abstract class DifferenceCheckerBase<T>: IDifferenceCalculator<T> where T : struct {
    
    public abstract bool IsConsistent(IReadOnlyList<T>? numbers);
    // Event triggered when the difference is calculated
    public event Action<string>? OnDifferenceChecked;

    protected void Notify(string message){
        OnDifferenceChecked?.Invoke(message);
    }
}