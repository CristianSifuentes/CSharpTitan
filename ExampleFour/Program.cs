class Program {
    static void Main(){
        int[] array1 = [3, 4, 9, 9, 17, 20];
        int[] array2 = [8, 9, 40, 41];
        GreatestDifferenceCalculator calculator = new GreatestDifferenceCalculator();
        int[] numbers = calculator.Merge2(array1, array2);
        foreach (int number in numbers)
        {
            Console.WriteLine(number);
        }

       // merge([3, 4, 9, 9, 17, 20], [8, 9, 40, 41])
       // returns [3, 4, 8, 9, 9, 9, 17, 20, 40, 41]
       

    }

}