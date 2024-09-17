namespace EuclideanSpace
{
    using System;
    using System.Numerics;
    using System.Runtime.CompilerServices;

    /// <summary>
    /// Represents a point with three scalar components.
    /// </summary>
    /// <typeparam name="TScalar">The type of the components of the point.</typeparam>
    public readonly partial struct Point3<TScalar> :
        IEquatable<Point3<TScalar>>,
        IFormattable,
        IEqualityOperators<Point3<TScalar>, Point3<TScalar>, bool>,
        IAdditionOperators<Point3<TScalar>, Vector3<TScalar>, Point3<TScalar>>,
        ISubtractionOperators<Point3<TScalar>, Point3<TScalar>, Vector3<TScalar>>,
        ISubtractionOperators<Point3<TScalar>, Vector3<TScalar>, Point3<TScalar>>
        where TScalar : IAdditionOperators<TScalar, TScalar, TScalar>,
        IAdditiveIdentity<TScalar, TScalar>,
        IMultiplyOperators<TScalar, TScalar, TScalar>,
        ISubtractionOperators<TScalar, TScalar, TScalar>,
        IUnaryNegationOperators<TScalar, TScalar>,
        IDivisionOperators<TScalar, TScalar, TScalar>
    {
        internal readonly TScalar _x;
        private readonly TScalar _y;
        private readonly TScalar _z;

        /// <summary>
        /// Creates a new <see cref="Point3{T}" /> instance whose components have the same value.
        /// </summary>
        /// <param name="value">The value to assign to all components.</param>
        public Point3(TScalar value) : this(value, value, value) { }

        /// <summary>
        /// Creates a point whose components have the specified values.
        /// </summary>
        /// <param name="x">The value to assign to the <see cref="X" /> component.</param>
        /// <param name="y">The value to assign to the <see cref="Y" /> component.</param>
        /// <param name="z">The value to assign to the <see cref="Z" /> component.</param>
        public Point3(TScalar x, TScalar y, TScalar z)
        {
            _x = x;
            _y = y;
            _z = z;
        }

        /// <summary>
        /// Constructs a point from the given <see cref="ReadOnlySpan{TScalar}" />. The span must contain at least 3 elements.
        /// </summary>
        /// <param name="values">The span of elements to assign to the point.</param>
        public Point3(ReadOnlySpan<TScalar> values)
        {
            if (values.Length < Point3.Count)
                ThrowHelpers.ThrowArgumentOutOfRangeException(nameof(values));

            _x = values[0];
            _y = values[1];
            _z = values[2];
        }

        ///<summary>The X component of the point.</summary>
        public TScalar X => _x;

        ///<summary>The Y component of the point.</summary>
        public TScalar Y => _y;

        ///<summary>The Z component of the point.</summary>
        public TScalar Z => _z;

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
        public static Point3<TScalar> operator +(Point3<TScalar> point, Vector3<TScalar> vector) =>
            new(point.X + vector.X, point.Y + vector.Y, point.Z + vector.Z);

        /// <inheritdoc />
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3<TScalar> operator -(Point3<TScalar> left, Point3<TScalar> right) =>
            new(left.X - right.X, left.Y - right.Y, left.Z - right.Z);

        /// <inheritdoc />
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point3<TScalar> operator -(Point3<TScalar> left, Vector3<TScalar> right) =>
            new(left.X - right.X, left.Y - right.Y, left.Z - right.Z);
    }
}
