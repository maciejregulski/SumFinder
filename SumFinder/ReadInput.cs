﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace SumFinder
{
    public class ReadInput
    {
        private const string InputFileName = "numbers.txt";

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

        public static string InputFilePath => Path.Combine(AssemblyDirectory, InputFileName);

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
                            if (decimal.TryParse(line.Replace('.', ','), out number))
                            {
                                list.Add(number);
                            }
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