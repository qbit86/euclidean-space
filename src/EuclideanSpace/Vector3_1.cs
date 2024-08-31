namespace EuclideanSpace
{
    using System;
    using System.Numerics;
    using System.Runtime.CompilerServices;

    /// <summary>
    /// Represents a vector with three scalar components.
    /// </summary>
    /// <typeparam name="TScalar">The type of the components of the vector.</typeparam>
    public readonly partial struct Vector3<TScalar> :
        IEquatable<Vector3<TScalar>>,
        IFormattable,
        IEqualityOperators<Vector3<TScalar>, Vector3<TScalar>, bool>,
        IAdditionOperators<Vector3<TScalar>, Vector3<TScalar>, Vector3<TScalar>>,
        IAdditiveIdentity<Vector3<TScalar>, Vector3<TScalar>>,
        IMultiplyOperators<Vector3<TScalar>, Vector3<TScalar>, Vector3<TScalar>>,
        IMultiplyOperators<Vector3<TScalar>, TScalar, Vector3<TScalar>>,
        ISubtractionOperators<Vector3<TScalar>, Vector3<TScalar>, Vector3<TScalar>>,
        IUnaryNegationOperators<Vector3<TScalar>, Vector3<TScalar>>,
        IDivisionOperators<Vector3<TScalar>, Vector3<TScalar>, Vector3<TScalar>>,
        IDivisionOperators<Vector3<TScalar>, TScalar, Vector3<TScalar>>
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
        /// Creates a new <see cref="Vector3{T}"/> instance whose components have the same value.
        /// </summary>
        /// <param name="value">The value to assign to all components.</param>
        public Vector3(TScalar value) : this(value, value, value) { }

        /// <summary>
        /// Creates a vector whose components have the specified values.
        /// </summary>
        /// <param name="x">The value to assign to the <see cref="X"/> component.</param>
        /// <param name="y">The value to assign to the <see cref="Y"/> component.</param>
        /// <param name="z">The value to assign to the <see cref="Z"/> component.</param>
        public Vector3(TScalar x, TScalar y, TScalar z)
        {
            _x = x;
            _y = y;
            _z = z;
        }

        /// <summary>
        /// Constructs a vector from the given <see cref="ReadOnlySpan{TScalar}"/>. The span must contain at least 3 elements.
        /// </summary>
        /// <param name="values">The span of elements to assign to the vector.</param>
        public Vector3(ReadOnlySpan<TScalar> values)
        {
            if (values.Length < Vector3.Count)
                ThrowHelpers.ThrowArgumentOutOfRangeException(nameof(values));

            _x = values[0];
            _y = values[1];
            _z = values[2];
        }

        public TScalar X => _x;

        public TScalar Y => _y;

        public TScalar Z => _z;

        public static Vector3<TScalar> AdditiveIdentity
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
        public TScalar LengthSquared() => Vector3.Dot(this, this);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3<TScalar> operator +(Vector3<TScalar> left, Vector3<TScalar> right) =>
            new(left.X + right.X, left.Y + right.Y, left.Z + right.Z);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3<TScalar> operator *(Vector3<TScalar> left, Vector3<TScalar> right) =>
            new(left.X * right.X, left.Y * right.Y, left.Z * right.Z);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3<TScalar> operator *(Vector3<TScalar> left, TScalar right) =>
            left * new Vector3<TScalar>(right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3<TScalar> operator *(TScalar scalar, Vector3<TScalar> vector) =>
            new Vector3<TScalar>(scalar) * vector;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3<TScalar> operator -(Vector3<TScalar> left, Vector3<TScalar> right) =>
            new(left.X - right.X, left.Y - right.Y, left.Z - right.Z);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3<TScalar> operator -(Vector3<TScalar> value) =>
            new(-value.X, -value.Y, -value.Z);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3<TScalar> operator /(Vector3<TScalar> left, Vector3<TScalar> right) =>
            new(left.X / right.X, left.Y / right.Y, left.Z / right.Z);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3<TScalar> operator /(Vector3<TScalar> left, TScalar right) =>
            left / new Vector3<TScalar>(right);
    }
}
