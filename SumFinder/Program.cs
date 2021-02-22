using System;
using System.IO;

namespace SumFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            //var numbers = new List<decimal>() { 3.1m, 9, 8, 4, 5, 7, 10 };
            string filePath = ReadInput.InputFilePath;
            if (File.Exists(filePath))
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"Odczytuję dane z pliku:{Environment.NewLine}{filePath}");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Nie można znaleźć pliku z danymi:{Environment.NewLine}{filePath}");
            }
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            var input = new ReadInput().ParseNumbersFile(filePath);
            if (input.Count > 1)
            {
                decimal target = input[0];
                input.RemoveAt(0);
                new SumFinder().FindSums(input, target);
            }
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Naciśnij Enter");
            Console.ReadLine();
        }
    }
}
