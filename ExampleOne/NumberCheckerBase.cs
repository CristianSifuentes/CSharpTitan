// Abstract base class enforcing a contract for checking numbers
public abstract class NumberCheckerBase<T>{
    public T Number { get; set; }
    protected NumberCheckerBase(T number){
      number = Number;
    }
    public abstract bool Contains();
}

 