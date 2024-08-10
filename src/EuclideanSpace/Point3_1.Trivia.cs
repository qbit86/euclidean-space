namespace EuclideanSpace
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Runtime.CompilerServices;

    public readonly partial struct Point3<TScalar>
    {
        public string ToString(string? format, IFormatProvider? formatProvider)
        {
            FormattableString formattable = $"<{_x}, {_y}, {_z}>";
            return formattable.ToString(formatProvider);
        }

        public override string ToString() => ToString("G", CultureInfo.InvariantCulture);

        public bool Equals(Point3<TScalar> other)
        {
            var c = EqualityComparer<TScalar>.Default;
            return c.Equals(_x, other._x) && c.Equals(_y, other._y) && c.Equals(_z, other._z);
        }

        public override bool Equals(object? obj) => obj is Point3<TScalar> other && Equals(other);

        public override int GetHashCode() => HashCode.Combine(_x, _y, _z);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(Point3<TScalar> left, Point3<TScalar> right) => left.Equals(right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(Point3<TScalar> left, Point3<TScalar> right) => !left.Equals(right);
    }
}
