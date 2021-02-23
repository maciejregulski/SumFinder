// ReadInput.cs
//
// Comments : 
// Date     : 2021/02/22
// Author   : Maciej Regulski
// <copyright file="ReadInput.cs" company="Datacom Maciej Regulski">
//     Copyright (c) Maciej Regulski.
// </copyright>

using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace SumFinder
{
    public class ReadInput
    {
        private const string InputFileName = "numbers2.txt";

        /// <summary>
        /// Gets the path of the running assembly.
        /// </summary>
        public static string AssemblyDirectory
        {
            get
            {
                string codeBase = Assembly.GetExecutingAssembly().CodeBase;
                UriBuilder uri = new UriBuilder(codeBase);
                string path = Uri.UnescapeDataString(uri.Path);
                return Path.GetDirectoryName(path);
            }
        }

        /// <summary>
        /// Gets the path of the input text file.
        /// </summary>
        public static string InputFilePath => Path.Combine(AssemblyDirectory, InputFileName);

        /// <summary>
        /// Reads the input text file line by line and parses the decimal numbers.
        /// Replaces decimal point separator according to system environment settings.
        /// </summary>
        /// <param name="filePath">The path of the input text file.</param>
        /// <returns>List of the parsed numbers.</returns>
        public List<decimal> ParseNumbersFile(string filePath)
        {
            var list = new List<decimal>();

            if (File.Exists(filePath))
            {
                try
                {
                    string line = null;
                    decimal number;

                    using (TextReader reader = File.OpenText(filePath))
                    {
                        while ((line = reader.ReadLine()) != null)
                        {
                            number = line.ToInvariantDecimal(out bool success);
                            if (success)
                            {
                                list.Add(number);
                            }
                            //if (decimal.TryParse(line.Replace('.', ','), out number))
                            //{
                            //    list.Add(number);
                            //}
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }

            return list;
        }
    }
}
