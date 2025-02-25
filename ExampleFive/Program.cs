using System;

namespace ExampleFive
{
    class Program
    {
        static void Main(string[] args)
        {

            /*
            yield is a special keyword in C# used to produce elements on demand rather than computing all elements at once.
            */
            /*
            yield es una palabra clave especial en C# que se utiliza para producir elementos bajo demanda en lugar de calcular todos los elementos a la vez.

            */

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