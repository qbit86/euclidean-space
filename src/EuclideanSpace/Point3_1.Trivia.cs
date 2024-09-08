namespace EuclideanSpace
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Runtime.CompilerServices;

    public readonly partial struct Point3<TScalar>
    {
        /// <inheritdoc />
        public string ToString(string? format, IFormatProvider? formatProvider)
        {
            FormattableString formattable = $"<{_x}, {_y}, {_z}>";
            return formattable.ToString(formatProvider);
        }

        /// <summary>Returns the string representation of the current instance using default formatting.</summary>
        /// <returns>The string representation of the current instance.</returns>
        public override string ToString() => ToString("G", CultureInfo.InvariantCulture);

        /// <inheritdoc />
        public bool Equals(Point3<TScalar> other)
        {
            var c = EqualityComparer<TScalar>.Default;
            return c.Equals(_x, other._x) && c.Equals(_y, other._y) && c.Equals(_z, other._z);
        }

        /// <inheritdoc />
        public override bool Equals(object? obj) => obj is Point3<TScalar> other && Equals(other);

        /// <inheritdoc />
        public override int GetHashCode() => HashCode.Combine(_x, _y, _z);

        /// <inheritdoc />
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(Point3<TScalar> left, Point3<TScalar> right) => left.Equals(right);

        /// <inheritdoc />
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(Point3<TScalar> left, Point3<TScalar> right) => !left.Equals(right);
    }
}
