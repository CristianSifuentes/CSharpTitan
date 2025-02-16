// Concrete implementation for numeric types 
public class NumberChecker<T> : NumberCheckerBase<T>
{
    public NumberChecker(T number) : base(number){
    }

    public override bool Contains()
    {
        throw new NotImplementedException();
    }
} 