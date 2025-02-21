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

        }
    }
}