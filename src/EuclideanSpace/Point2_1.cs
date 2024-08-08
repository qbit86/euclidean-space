namespace EuclideanSpace
{
    using System;
    using System.Numerics;
    using System.Runtime.CompilerServices;

    public readonly partial struct Point2<TScalar> :
        IEquatable<Point2<TScalar>>,
        IFormattable,
        IEqualityOperators<Point2<TScalar>, Point2<TScalar>, bool>,
        IAdditionOperators<Point2<TScalar>, Vector2<TScalar>, Point2<TScalar>>,
        IMultiplyOperators<Point2<TScalar>, TScalar, Point2<TScalar>>,
        ISubtractionOperators<Point2<TScalar>, Point2<TScalar>, Vector2<TScalar>>,
        IUnaryNegationOperators<Point2<TScalar>, Point2<TScalar>>,
        IDivisionOperators<Point2<TScalar>, TScalar, Point2<TScalar>>
        where TScalar : IAdditionOperators<TScalar, TScalar, TScalar>,
        IMultiplyOperators<TScalar, TScalar, TScalar>,
        ISubtractionOperators<TScalar, TScalar, TScalar>,
        IUnaryNegationOperators<TScalar, TScalar>,
        IDivisionOperators<TScalar, TScalar, TScalar>
    {
        internal readonly TScalar _x;
        private readonly TScalar _y;

        public Point2(TScalar value) : this(value, value) { }

        public Point2(TScalar x, TScalar y)
        {
            _x = x;
            _y = y;
        }

        public Point2(ReadOnlySpan<TScalar> elements)
        {
            if (elements.Length < Point2.Count)
                ThrowHelpers.ThrowArgumentOutOfRangeException(nameof(elements));

            _x = elements[0];
            _y = elements[1];
        }

        public TScalar X => _x;

        public TScalar Y => _y;

        public TScalar this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => this.GetElement(index);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point2<TScalar> operator +(Point2<TScalar> point, Vector2<TScalar> vector) =>
            new(point.X + vector.X, point.Y + vector.Y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point2<TScalar> operator *(Point2<TScalar> left, TScalar right) =>
            new(left.X * right, left.Y * right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point2<TScalar> operator *(TScalar scalar, Point2<TScalar> point) =>
            new(scalar * point.X, scalar * point.Y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2<TScalar> operator -(Point2<TScalar> left, Point2<TScalar> right) =>
            new(left.X - right.X, left.Y - right.Y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point2<TScalar> operator -(Point2<TScalar> value) =>
            new(-value.X, -value.Y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point2<TScalar> operator /(Point2<TScalar> left, TScalar right) =>
            new(left.X / right, left.Y / right);
    }
}
