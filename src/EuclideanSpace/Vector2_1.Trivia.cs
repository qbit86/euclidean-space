namespace EuclideanSpace
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Numerics;
    using System.Runtime.CompilerServices;

    public readonly partial struct Vector2<TScalar>
    {
        /// <inheritdoc cref="IFormattable.ToString(string?, IFormatProvider?)" />
        public string ToString(string? format, IFormatProvider? formatProvider)
        {
            FormattableString formattable = $"<{_x}, {_y}>";
            return formattable.ToString(formatProvider);
        }

        /// <summary>Returns the string representation of the current instance using default formatting.</summary>
        /// <returns>The string representation of the current instance.</returns>
        public override string ToString() => ToString("G", CultureInfo.InvariantCulture);

        /// <inheritdoc cref="IEquatable{T}.Equals(T?)" />
        public bool Equals(Vector2<TScalar> other)
        {
            var c = EqualityComparer<TScalar>.Default;
            return c.Equals(_x, other._x) && c.Equals(_y, other._y);
        }

        /// <inheritdoc cref="object.Equals(object?)" />
        public override bool Equals(object? obj) => obj is Vector2<TScalar> other && Equals(other);

        /// <inheritdoc cref="object.GetHashCode" />
        public override int GetHashCode() => HashCode.Combine(_x, _y);

        /// <inheritdoc cref="IEqualityOperators{TSelf,TOther,TResult}.operator ==" />
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(Vector2<TScalar> left, Vector2<TScalar> right) => left.Equals(right);

        /// <inheritdoc cref="IEqualityOperators{TSelf,TOther,TResult}.operator !=" />
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(Vector2<TScalar> left, Vector2<TScalar> right) => !left.Equals(right);
    }
}
