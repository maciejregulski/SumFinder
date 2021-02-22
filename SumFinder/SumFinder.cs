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
        private decimal delta = .001m;

        public void FindSums(List<decimal> numbers, decimal target)
        {
            SumUpRecursive(numbers, target, new List<decimal>());
        }

        private void SumUpRecursive(List<decimal> numbers, decimal target, List<decimal> partial)
        {
            decimal sum = default(decimal);

            foreach (decimal num in partial)
            {
                sum += num;
            }

            if (Math.Abs(sum - target) < delta)
            {
                // Values are within specified tolerance of each other...
                Console.WriteLine("Znaleziono sumę w granicach tolerancji: " + string.Join("+", partial.ToArray()) + "=" + partial.Sum());
            }

            if (sum == target)
            {
                Console.WriteLine("Znaleziono sumę: " + string.Join("+", partial.ToArray()) + "=" + target);
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
