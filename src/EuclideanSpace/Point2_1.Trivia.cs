namespace EuclideanSpace
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;

    public readonly partial struct Point2<TScalar>
    {
        public string ToString(string? format, IFormatProvider? formatProvider)
        {
            FormattableString formattable = $"<{_x}, {_y}>";
            return formattable.ToString(formatProvider);
        }

        public override string ToString() => ToString("G", CultureInfo.InvariantCulture);

        public bool Equals(Point2<TScalar> other)
        {
            var c = EqualityComparer<TScalar>.Default;
            return c.Equals(_x, other._x) && c.Equals(_y, other._y);
        }

        public override bool Equals(object? obj) => obj is Point2<TScalar> other && Equals(other);

        public override int GetHashCode() => HashCode.Combine(_x, _y);

        public static bool operator ==(Point2<TScalar> left, Point2<TScalar> right) => left.Equals(right);

        public static bool operator !=(Point2<TScalar> left, Point2<TScalar> right) => !left.Equals(right);
    }
}
