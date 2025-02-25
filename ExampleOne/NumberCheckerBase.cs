// Delegate to define a generic checking condition
// A delegate is a type that represents references to methods with a particular parameter list and return type.
// This defines a new delegate type named CheckCondition<T>, which can store any compatible method.
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
    /// <summary>
    /// Abstract method to check if a number is contained in a collection
    /// </summary>
    /// <param name="collection"></param>
    /// <param name="item"></param>
    /// <param name="threshold"></param>
    /// <returns></returns>
    public abstract bool Contains(IEnumerable<T> collection, T item, int threshold);
}

 