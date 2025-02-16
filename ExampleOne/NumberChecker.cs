// Concrete implementation for numeric types 
public class NumberChecker<T> : NumberCheckerBase<T>
{
    public NumberChecker(CheckCondition<T> conditionChecker) : base(conditionChecker){
    }

    public override bool Contains()
    {
        throw new NotImplementedException();
    }
} 