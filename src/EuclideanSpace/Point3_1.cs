namespace EuclideanSpace
{
    using System;
    using System.Numerics;
    using System.Runtime.CompilerServices;

    public readonly partial struct Point3<TScalar> :
        IEquatable<Point3<TScalar>>,
        IFormattable,
        IEqualityOperators<Point3<TScalar>, Point3<TScalar>, bool>,
        IAdditionOperators<Point3<TScalar>, Vector3<TScalar>, Point3<TScalar>>,
        IMultiplyOperators<Point3<TScalar>, TScalar, Point3<TScalar>>,
        ISubtractionOperators<Point3<TScalar>, Point3<TScalar>, Vector3<TScalar>>,
        ISubtractionOperators<Point3<TScalar>, Vector3<TScalar>, Point3<TScalar>>,
        IUnaryNegationOperators<Point3<TScalar>, Point3<TScalar>>,
        IDivisionOperators<Point3<TScalar>, TScalar, Point3<TScalar>>
        where TScalar : IAdditionOperators<TScalar, TScalar, TScalar>,
        IMultiplyOperators<TScalar, TScalar, TScalar>,
        ISubtractionOperators<TScalar, TScalar, TScalar>,
        IUnaryNegationOperators<TScalar, TScalar>,
        IDivisionOperators<TScalar, TScalar, TScalar>
    {
        internal readonly TScalar _x;
        private readonly TScalar _y;
        private readonly TScalar _z;

        public Point3(TScalar value) : this(value, value, value) { }

        public Point3(TScalar x, TScalar y, TScalar z)
        {
            _x = x;
            _y = y;
            _z = z;
        }

        public Point3(ReadOnlySpan<TScalar> elements)
        {
            if (elements.Length < Point3.Count)
                ThrowHelpers.ThrowArgumentOutOfRangeException(nameof(elements));

            _x = elements[0];
            _y = elements[1];
            _z = elements[2];
        }

        public TScalar X => _x;

        public TScalar Y => _y;

        public TScalar Z => _z;

        public TScalar this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => this.GetElement(index);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point3<TScalar> operator +(Point3<TScalar> point, Vector3<TScalar> vector) =>
            new(point.X + vector.X, point.Y + vector.Y, point.Z + vector.Z);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point3<TScalar> operator *(Point3<TScalar> left, TScalar right) =>
            new(left.X * right, left.Y * right, left.Z * right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point3<TScalar> operator *(TScalar scalar, Point3<TScalar> point) =>
            new(scalar * point.X, scalar * point.Y, scalar * point.Z);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3<TScalar> operator -(Point3<TScalar> left, Point3<TScalar> right) =>
            new(left.X - right.X, left.Y - right.Y, left.Z - right.Z);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point3<TScalar> operator -(Point3<TScalar> left, Vector3<TScalar> right) =>
            new(left.X - right.X, left.Y - right.Y, left.Z - right.Z);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point3<TScalar> operator -(Point3<TScalar> value) =>
            new(-value.X, -value.Y, -value.Z);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point3<TScalar> operator /(Point3<TScalar> left, TScalar right) =>
            new(left.X / right, left.Y / right, left.Z / right);
    }
}
