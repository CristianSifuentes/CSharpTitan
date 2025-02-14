// Abstract base class enforcing a contract for checking numbers
public abstract class NumberCheckerBase<T>{
    protected CheckCondition<T> ConditionChecker { get; }

    protected NumberCheckerBase(CheckCondition<T> conditionChecker){
        ConditionChecker = conditionChecker ?? throw new ArgumentNullException(nameof(conditionChecker));
    }

    public abstract bool Contains(IEnumerable<T> collection, T item, int minOccurrences);
}
