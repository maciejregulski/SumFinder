// SumFinder.cs
//
// Comments : 
// Date     : 2021/02/22
// Author   : Maciej Regulski
// <copyright file="SumFinder.cs" company="Datacom Maciej Regulski">
//     Copyright (c) Maciej Regulski.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;

namespace SumFinder
{
    // There is no generic numeric type in C#
    //public class SumFinder<T> where T : struct, IComparable<T>, IComparable, IConvertible, IEquatable<T>, IFormattable
    public class SumFinder
    {
        /// <summary>
        /// Define a tolerance value.
        /// </summary>
        private decimal delta = .05m;

        /// <summary>
        /// Finds all possible combinations of numbers to reach a given sum.
        /// </summary>
        /// <param name="numbers">Input numbers.</param>
        /// <param name="target">Final number.</param>
        public void FindSums(List<decimal> numbers, decimal target)
        {
            SumUpRecursive(numbers, target, new List<decimal>());
        }

        /// <summary>
        /// Search recursive for the sums that match the target.
        /// </summary>
        /// <param name="numbers">Input numbers.</param>
        /// <param name="target">Expected result.</param>
        /// <param name="partial">Partial sum.</param>
        private void SumUpRecursive(List<decimal> numbers, decimal target, List<decimal> partial)
        {
            decimal sum = default(decimal);

            foreach (decimal num in partial)
            {
                sum += num;
            }

            // Values are within specified tolerance of each other
            if (Math.Abs(sum - target) < delta)
            {
                Console.WriteLine($"Znaleziono sumę cząstkową w granicach tolerancji: {string.Join("+", partial.ToArray())}={partial.Sum()}");
            }

            if (sum == target)
            {
                Console.WriteLine($"Znaleziono sumę cząstkową: {string.Join("+", partial.ToArray())}={target}");
            }

            if (sum > target)
            {
                return;
            }

            for (int i = 0; i < numbers.Count; i++)
            {
                var remaining = new List<decimal>();
                decimal num = numbers[i];

                for (int j = i + 1; j < numbers.Count; j++)
                {
                    remaining.Add(numbers[j]);
                }

                var partialRec = new List<decimal>(partial);
                partialRec.Add(num);

                SumUpRecursive(remaining, target, partialRec);
            }
        }
    }
}
