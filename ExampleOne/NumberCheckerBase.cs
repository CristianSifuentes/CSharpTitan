// Delegate to define a generic checking condition
public delegate bool CheckCondition<T>(IEnumerable<T> collection, T item, int threshold );


// Abstract base class enforcing a contract for checking numbers
public abstract class NumberCheckerBase<T>{
    protected CheckCondition<T> ConditionChecker  { get; }
    //Whats is the difference between { get; } and readonly?
    protected NumberCheckerBase(CheckCondition<T> conditionChecker){
        // Null-Coalescing Operator
        // retrieves the name of the parameter ("conditionChecker") as a string.
        ConditionChecker = conditionChecker ?? throw new ArgumentNullException(nameof(conditionChecker));
    }
    public abstract bool Contains();
}

 