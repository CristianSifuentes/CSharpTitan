// Concrete implementation for numeric types 
// where T: struct -> Ensures that the class works only with value types (numbers), int, float, double, etc.
public class NumberChecker<T> : NumberCheckerBase<T> where T: struct
{
    public NumberChecker(CheckCondition<T> conditionChecker) : base(conditionChecker){
    }

    public override bool Contains(IEnumerable<T> collection, T item, int threshold){
        return ConditionChecker(collection, item, threshold);
    }
} 