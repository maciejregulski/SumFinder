// DecimalExtensions.cs
//
// Comments : 
// Date     : 2019/10/30
// Author   : Maciej Regulski
// <copyright file="DecimalExtensions.cs" company="Datacom Maciej Regulski">
//     Copyright (c) Maciej Regulski.
// </copyright>

using System.Globalization;

namespace SumFinder
{
    /// <summary>Extension methods. Parse a string with a decimal point to a decimal and opposite.</summary>
    public static class DecimalExtensions
    {
        /// <summary>Converts to invariant decimal. Replaces the comma with a dot before parsing. Useful in countries with a comma as decimal separator. Think about limiting user input (if necessary) to one comma or dot.</summary>
        /// <param name="value">The value.</param>
        /// <param name="success">If set to true [success].</param>
        /// <returns>Converted value.</returns>
        public static decimal ToInvariantDecimal(this string value, out bool success)
        {
            if (string.IsNullOrEmpty(value))
            {
                success = false;
                return decimal.Zero;
            }
            success = decimal.TryParse(value.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out decimal result);
            return result;
        }

        /// <summary>Converts to invariant string.</summary>
        /// <param name="value">The value.</param>
        /// <returns>Converted value.</returns>
        public static string ToInvariantString(this decimal value)
        {
            return value.ToString(CultureInfo.InvariantCulture);
        }

        /// <summary>Converts to invariant string.</summary>
        /// <param name="value">The value.</param>
        /// <param name="format">Precision specifier. Number of decimal digits.</param>
        /// <returns>Converted value.</returns>
        public static string ToInvariantString(this decimal value, string format)
        {
            return value.ToString(format, CultureInfo.InvariantCulture);
        }
    }
}
