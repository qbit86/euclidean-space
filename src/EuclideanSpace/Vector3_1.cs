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

        ///<summary>The X component of the vector.</summary>
        public TScalar X => _x;

        /// <summary>The Y component of the vector.</summary>
        public TScalar Y => _y;

        /// <summary>The Z component of the vector.</summary>
        public TScalar Z => _z;

        /// <inheritdoc cref="IAdditiveIdentity{TSelf, TResult}.AdditiveIdentity" />
        public static Vector3<TScalar> AdditiveIdentity
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => new(TScalar.AdditiveIdentity);
        }

        /// <summary>Gets the element at the specified index.</summary>
        /// <param name="index">The index of the element to get.</param>
        /// <returns>The element at <paramref name="index" />.</returns>
        /// /// <exception cref="ArgumentOutOfRangeException"><paramref name="index" /> was less than zero or greater than the number of elements.</exception>
        public TScalar this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => this.GetElement(index);
        }

        /// <summary>Returns the length of the vector squared.</summary>
        /// <returns>The vector's length squared.</returns>
        /// <remarks>This operation offers better performance than a call to the <see cref="Vector3.Length{TScalar}" /> method.</remarks>
        /// <altmember cref="Vector3.Length{TScalar}"/>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public TScalar LengthSquared() => Vector3.Dot(this, this);

        /// <inheritdoc cref="IAdditionOperators{TSelf, TOther, TResult}.operator +" />
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3<TScalar> operator +(Vector3<TScalar> left, Vector3<TScalar> right) =>
            new(left.X + right.X, left.Y + right.Y, left.Z + right.Z);

        /// <inheritdoc cref="IMultiplyOperators{TSelf, TOther, TResult}.operator *" />
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3<TScalar> operator *(Vector3<TScalar> left, Vector3<TScalar> right) =>
            new(left.X * right.X, left.Y * right.Y, left.Z * right.Z);

        /// <summary>Multiplies the specified vector by the specified scalar value.</summary>
        /// <param name="left">The vector.</param>
        /// <param name="right">The scalar value.</param>
        /// <returns>The scaled vector.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3<TScalar> operator *(Vector3<TScalar> left, TScalar right) =>
            left * new Vector3<TScalar>(right);

        /// <summary>Multiplies the scalar value by the specified vector.</summary>
        /// <param name="scalar">The scalar value.</param>
        /// <param name="vector">The vector.</param>
        /// <returns>The scaled vector.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3<TScalar> operator *(TScalar scalar, Vector3<TScalar> vector) =>
            new Vector3<TScalar>(scalar) * vector;

        /// <inheritdoc cref="ISubtractionOperators{TSelf, TOther, TResult}.operator -" />
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3<TScalar> operator -(Vector3<TScalar> left, Vector3<TScalar> right) =>
            new(left.X - right.X, left.Y - right.Y, left.Z - right.Z);

        /// <inheritdoc cref="IUnaryNegationOperators{TSelf, TResult}.op_UnaryNegation(TSelf)" />
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3<TScalar> operator -(Vector3<TScalar> value) =>
            new(-value.X, -value.Y, -value.Z);

        /// <inheritdoc cref="IDivisionOperators{TSelf, TOther, TResult}.operator /" />
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3<TScalar> operator /(Vector3<TScalar> left, Vector3<TScalar> right) =>
            new(left.X / right.X, left.Y / right.Y, left.Z / right.Z);

        /// <summary>Divides the specified vector by the specified scalar value.</summary>
        /// <param name="left">The vector.</param>
        /// <param name="right">The scalar value.</param>
        /// <returns>The vector that results from the division.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3<TScalar> operator /(Vector3<TScalar> left, TScalar right) =>
            left / new Vector3<TScalar>(right);
    }
}
