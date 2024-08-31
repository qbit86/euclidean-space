namespace EuclideanSpace
{
    using System;
    using System.Numerics;
    using System.Runtime.CompilerServices;

    /// <summary>
    /// Represents a vector with two scalar components.
    /// </summary>
    /// <typeparam name="TScalar">The type of the components of the vector.</typeparam>
    public readonly partial struct Vector2<TScalar> :
        IEquatable<Vector2<TScalar>>,
        IFormattable,
        IEqualityOperators<Vector2<TScalar>, Vector2<TScalar>, bool>,
        IAdditionOperators<Vector2<TScalar>, Vector2<TScalar>, Vector2<TScalar>>,
        IAdditiveIdentity<Vector2<TScalar>, Vector2<TScalar>>,
        IMultiplyOperators<Vector2<TScalar>, Vector2<TScalar>, Vector2<TScalar>>,
        IMultiplyOperators<Vector2<TScalar>, TScalar, Vector2<TScalar>>,
        ISubtractionOperators<Vector2<TScalar>, Vector2<TScalar>, Vector2<TScalar>>,
        IUnaryNegationOperators<Vector2<TScalar>, Vector2<TScalar>>,
        IDivisionOperators<Vector2<TScalar>, Vector2<TScalar>, Vector2<TScalar>>,
        IDivisionOperators<Vector2<TScalar>, TScalar, Vector2<TScalar>>
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
        /// Creates a new <see cref="Vector2{T}"/> instance whose components have the same value.
        /// </summary>
        /// <param name="value">The value to assign to all components.</param>
        public Vector2(TScalar value) : this(value, value) { }

        /// <summary>
        /// Creates a vector whose components have the specified values.
        /// </summary>
        /// <param name="x">The value to assign to the <see cref="X"/> component.</param>
        /// <param name="y">The value to assign to the <see cref="Y"/> component.</param>
        public Vector2(TScalar x, TScalar y)
        {
            _x = x;
            _y = y;
        }

        /// <summary>
        /// Constructs a vector from the given <see cref="ReadOnlySpan{TScalar}"/>. The span must contain at least 2 elements.
        /// </summary>
        /// <param name="values">The span of elements to assign to the vector.</param>
        public Vector2(ReadOnlySpan<TScalar> values)
        {
            if (values.Length < Vector2.Count)
                ThrowHelpers.ThrowArgumentOutOfRangeException(nameof(values));

            _x = values[0];
            _y = values[1];
        }

        public TScalar X => _x;

        public TScalar Y => _y;

        public static Vector2<TScalar> AdditiveIdentity
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => new(TScalar.AdditiveIdentity);
        }

        public TScalar this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => this.GetElement(index);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public TScalar LengthSquared() => Vector2.Dot(this, this);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2<TScalar> operator +(Vector2<TScalar> left, Vector2<TScalar> right) =>
            new(left.X + right.X, left.Y + right.Y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2<TScalar> operator *(Vector2<TScalar> left, Vector2<TScalar> right) =>
            new(left.X * right.X, left.Y * right.Y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2<TScalar> operator *(Vector2<TScalar> left, TScalar right) =>
            left * new Vector2<TScalar>(right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2<TScalar> operator *(TScalar scalar, Vector2<TScalar> vector) =>
            new Vector2<TScalar>(scalar) * vector;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2<TScalar> operator -(Vector2<TScalar> left, Vector2<TScalar> right) =>
            new(left.X - right.X, left.Y - right.Y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2<TScalar> operator -(Vector2<TScalar> value) =>
            new(-value.X, -value.Y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2<TScalar> operator /(Vector2<TScalar> left, Vector2<TScalar> right) =>
            new(left.X / right.X, left.Y / right.Y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2<TScalar> operator /(Vector2<TScalar> left, TScalar right) =>
            left / new Vector2<TScalar>(right);
    }
}
