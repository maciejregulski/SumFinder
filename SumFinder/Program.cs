using System;

namespace SumFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            //var numbers = new List<decimal>() { 3.1m, 9, 8, 4, 5, 7, 10 };
            string filePath = ReadInput.InputFilePath;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Odczytuję dane z pliku: {filePath}");
            Console.ForegroundColor = ConsoleColor.Green;
            var input = new ReadInput().ParseNumbersFile(filePath);
            if (input.Count > 1)
            {
                decimal target = input[0];
                input.RemoveAt(0);
                new SumFinder().FindSums(input, target);
            }
            Console.WriteLine("Naciśnij Enter");
            Console.ReadLine();
        }
    }
}
