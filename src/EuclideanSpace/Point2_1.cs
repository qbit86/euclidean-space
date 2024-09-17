namespace EuclideanSpace
{
    using System;
    using System.Numerics;
    using System.Runtime.CompilerServices;

    /// <summary>
    /// Represents a point with two scalar components.
    /// </summary>
    /// <typeparam name="TScalar">The type of the components of the point.</typeparam>
    public readonly partial struct Point2<TScalar> :
        IEquatable<Point2<TScalar>>,
        IFormattable,
        IEqualityOperators<Point2<TScalar>, Point2<TScalar>, bool>,
        IAdditionOperators<Point2<TScalar>, Vector2<TScalar>, Point2<TScalar>>,
        ISubtractionOperators<Point2<TScalar>, Point2<TScalar>, Vector2<TScalar>>,
        ISubtractionOperators<Point2<TScalar>, Vector2<TScalar>, Point2<TScalar>>
        where TScalar : IAdditionOperators<TScalar, TScalar, TScalar>,
        IAdditiveIdentity<TScalar, TScalar>,
        IMultiplyOperators<TScalar, TScalar, TScalar>,
        ISubtractionOperators<TScalar, TScalar, TScalar>,
        IUnaryNegationOperators<TScalar, TScalar>,
        IDivisionOperators<TScalar, TScalar, TScalar>
    {
        internal readonly TScalar _x;
        private readonly TScalar _y;

        /// <summary>
        /// Creates a new <see cref="Point2{T}" /> instance whose components have the same value.
        /// </summary>
        /// <param name="value">The value to assign to all components.</param>
        public Point2(TScalar value) : this(value, value) { }

        /// <summary>
        /// Creates a point whose components have the specified values.
        /// </summary>
        /// <param name="x">The value to assign to the <see cref="X" /> component.</param>
        /// <param name="y">The value to assign to the <see cref="Y" /> component.</param>
        public Point2(TScalar x, TScalar y)
        {
            _x = x;
            _y = y;
        }

        /// <summary>
        /// Constructs a point from the given <see cref="ReadOnlySpan{TScalar}" />. The span must contain at least 2 elements.
        /// </summary>
        /// <param name="values">The span of elements to assign to the point.</param>
        public Point2(ReadOnlySpan<TScalar> values)
        {
            if (values.Length < Point2.Count)
                ThrowHelpers.ThrowArgumentOutOfRangeException(nameof(values));

            _x = values[0];
            _y = values[1];
        }

        ///<summary>The X component of the point.</summary>
        public TScalar X => _x;

        ///<summary>The Y component of the point.</summary>
        public TScalar Y => _y;

        /// <summary>Gets the element at the specified index.</summary>
        /// <param name="index">The index of the element to get.</param>
        /// <returns>The element at <paramref name="index" />.</returns>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="index" /> was less than zero or greater than the number of elements.</exception>
        public TScalar this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => this.GetElement(index);
        }

        /// <inheritdoc />
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point2<TScalar> operator +(Point2<TScalar> point, Vector2<TScalar> vector) =>
            new(point.X + vector.X, point.Y + vector.Y);

        /// <inheritdoc />
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2<TScalar> operator -(Point2<TScalar> left, Point2<TScalar> right) =>
            new(left.X - right.X, left.Y - right.Y);

        /// <inheritdoc />
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point2<TScalar> operator -(Point2<TScalar> left, Vector2<TScalar> right) =>
            new(left.X - right.X, left.Y - right.Y);
    }
}
