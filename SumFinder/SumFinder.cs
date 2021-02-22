using System;
using System.Collections.Generic;

namespace SumFinder
{
    // There is no generic numeric type in C#
    //public class SumFinder<T> where T : struct, IComparable<T>, IComparable, IConvertible, IEquatable<T>, IFormattable
    public class SumFinder
    {
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

            if (sum > target)
            {
                return;
            }

            if (sum == target)
            {
                Console.WriteLine("Znaleziono sumę: " + string.Join("+", partial.ToArray()) + "=" + target);
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
