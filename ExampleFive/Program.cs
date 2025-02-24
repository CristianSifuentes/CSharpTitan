using System;

namespace ExampleFive
{
    class Program
    {
        static void Main(string[] args)
        {
            BaseClass obj = new Class();
            // Console.WriteLine(obj.GetNumbers());
            foreach (var num in obj.GetNumbers()){
                Console.WriteLine(num);
            }

            // This is a list of numbers using the List<int> class from the System.Collections.Generic namespace
            foreach (var num in obj.GetNumbersUsingList()){
                Console.WriteLine(num);
            }

        }
    }
}