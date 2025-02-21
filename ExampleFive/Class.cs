public class Class : BaseClass{

    /// <summary>
    ///  This method returns a list of numbers using the yield keyword
    /// </summary>
    /// <returns></returns>
    public override IEnumerable<int> GetNumbers(){
       Console.WriteLine("Generating numbers...");
       //✔ yield return returns one value at a time.
       // The method will return 1, then 2, then 3, then 4, then 5
       // ✔ Execution pauses after each yield return. 
       // ✔ The method will not return all values at once.
       // ✔ The method will return the next value when the foreach loop requests it.   
       // ✔ Resumes where it left off on the next iteration.
       // ✔ The method will not return all values at once.
       // ✔ The method will return the next value when the foreach loop requests it.
       yield return 1; yield return 2; yield return 3; yield return 4; yield return 5;
    }
}