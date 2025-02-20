
using System.Linq;

public class GreatestDifferenceCalculator : NumberCheckerBase
{
    public override  int[] Merge1()
    {
       int[] numbers = new int[10];
        for (int i = 0; i < 10; i++)
        {
            numbers[i] = i;
        }
        return numbers;
    }

    public override int[] Merge2(int[] value1, int[] value2)
    {
        int[] numbers = new int[value1.Length + value2.Length];
        int i = 0;
        for (; i < value1.Length; i++)
        {
            numbers[i] = value1[i];
        }
        for (int j = 0; j < value2.Length; j++)
        {
            numbers[i] = value2[j];
            i++;
        }
        return numbers.OrderDescending().Distinct().ToArray().Reverse().ToArray();
       
    }

    // internal int[] Merge2(int[] value1, int[] value2)
    // {
    //     throw new NotImplementedException();
    // }
}