namespace EuclideanSpace
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using System.Runtime.CompilerServices;

    internal static class ThrowHelpers
    {
        [DoesNotReturn]
        internal static void ThrowArgumentOutOfRangeException(string paramName) =>
            throw new ArgumentOutOfRangeException(paramName);

        internal static void ThrowIfGreaterThanOrEqual<T>(
            T value, T other, [CallerArgumentExpression(nameof(value))] string? paramName = null)
            where T : IComparable<T>
        {
            if (value.CompareTo(other) >= 0)
                ThrowGreaterEqual(value, other, paramName);
        }

        [DoesNotReturn]
        private static void ThrowGreaterEqual<T>(T value, T other, string? paramName)
        {
            FormattableString formattable = $"{paramName} ('{value}') must be less than '{other}'.";
            throw new ArgumentOutOfRangeException(paramName, value, formattable.ToString(CultureInfo.InvariantCulture));
        }
    }
}
