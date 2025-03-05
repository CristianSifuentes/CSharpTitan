
public class EventDrivenChecker<T> : NumberCheckerBase<T>{

    public event Action<string>? OnConditionChecked;
    public EventDrivenChecker(CheckCondition<T> conditionChecker) : base(conditionChecker){
    }

    public override bool Contains(IEnumerable<T> collection, T item, int threshold){
        bool result = ConditionChecker(collection, item, threshold);
        OnConditionChecked?.Invoke($"The condition was checked and the result is {result}");
        return result;
    }
}