// Program.cs
//
// Comments : 
// Date     : 2021/02/22
// Author   : Maciej Regulski
// <copyright file="Program.cs" company="Datacom Maciej Regulski">
//     Copyright (c) Maciej Regulski.
// </copyright>

using System;
using System.IO;
using System.Linq;

namespace SumFinder
{
    class Program
    {
        const string ExampleFileName = @"numbers.txt";

        static void Main(string[] args)
        {
            var reader = new ReadInput();
            reader.FileName = (args != null && args.Length > 0) ? args[0] : ExampleFileName;
            string filePath = reader.InputFilePath;
            if (File.Exists(filePath))
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"Odczytuję dane z pliku:{Environment.NewLine}{filePath}");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Nie można znaleźć pliku z danymi:{Environment.NewLine}{filePath}");
                Console.WriteLine();
                Environment.Exit(0);
            }
            
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            
            var input = reader.ParseNumbersFile(filePath);
            if (input.Count > 1)
            {
                // First number is expected result.
                decimal target = input[0];
                input.RemoveAt(0);
                Console.WriteLine($"Szukam sumy cząstkowej dającej wartość: {target}");

                // Sum all the elements
                var sum = input.Sum();
                Console.WriteLine($"Suma wszystkich {input.Count} wartości z listy: {sum}");
                Console.WriteLine();
                new SumFinder().FindSums(input, target);
            }
            
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Naciśnij Enter");
            Console.ReadLine();
        }
    }
}
