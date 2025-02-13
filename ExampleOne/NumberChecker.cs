// Concrete implementation for numeric types
public class NumberChecker<T> : NumberCheckerBase<T> where T : struct{
    
    public NumberChecker(CheckCondition<T> conditionChecker) : base(conditionChecker) { }

    public override bool Contains(IEnumerable<T> collection, T item, int minOccurrences){
        return ConditionChecker(collection, item, minOccurrences);
    }
}