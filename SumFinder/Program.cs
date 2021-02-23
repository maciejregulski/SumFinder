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
        static void Main(string[] args)
        {
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
                // First number is expected result.
                decimal target = input[0];
                input.RemoveAt(0);
                Console.WriteLine($"Szukam sumy cząstkowej dającej wartość: {target}");

                // Sum all the elements
                var sum = input.Sum();
                Console.WriteLine($"Suma wszystkich {input.Count} wartości z listy: {sum}");

                new SumFinder().FindSums(input, target);
            }
            
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Naciśnij Enter");
            Console.ReadLine();
        }
    }
}
