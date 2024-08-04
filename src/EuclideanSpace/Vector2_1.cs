namespace EuclideanSpace
{
    using System;
    using System.Numerics;
    using System.Runtime.CompilerServices;

    /// <summary>
    /// Represents a vector with two components.
    /// </summary>
    /// <typeparam name="TScalar">The type of the scalar.</typeparam>
    public readonly partial struct Vector2<TScalar> :
        IEquatable<Vector2<TScalar>>,
        IFormattable,
        IEqualityOperators<Vector2<TScalar>, Vector2<TScalar>, bool>,
        IAdditionOperators<Vector2<TScalar>, Vector2<TScalar>, Vector2<TScalar>>,
        IMultiplyOperators<Vector2<TScalar>, Vector2<TScalar>, Vector2<TScalar>>,
        IMultiplyOperators<Vector2<TScalar>, TScalar, Vector2<TScalar>>,
        ISubtractionOperators<Vector2<TScalar>, Vector2<TScalar>, Vector2<TScalar>>,
        IUnaryNegationOperators<Vector2<TScalar>, Vector2<TScalar>>,
        IDivisionOperators<Vector2<TScalar>, Vector2<TScalar>, Vector2<TScalar>>,
        IDivisionOperators<Vector2<TScalar>, TScalar, Vector2<TScalar>>
        where TScalar : IAdditionOperators<TScalar, TScalar, TScalar>,
        IMultiplyOperators<TScalar, TScalar, TScalar>,
        ISubtractionOperators<TScalar, TScalar, TScalar>,
        IUnaryNegationOperators<TScalar, TScalar>,
        IDivisionOperators<TScalar, TScalar, TScalar>
    {
        internal readonly TScalar _x;
        private readonly TScalar _y;

        public Vector2(TScalar value) : this(value, value) { }

        public Vector2(TScalar x, TScalar y)
        {
            _x = x;
            _y = y;
        }

        public Vector2(ReadOnlySpan<TScalar> elements)
        {
            if (elements.Length < Vector2.Count)
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
        public TScalar LengthSquared() => Vector2.Dot(this, this);

        public static Vector2<TScalar> operator +(Vector2<TScalar> left, Vector2<TScalar> right) =>
            new(left.X + right.X, left.Y + right.Y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2<TScalar> operator *(Vector2<TScalar> left, Vector2<TScalar> right) =>
            new(left.X * right.X, left.Y * right.Y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2<TScalar> operator *(Vector2<TScalar> left, TScalar right) =>
            left * new Vector2<TScalar>(right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2<TScalar> operator *(TScalar left, Vector2<TScalar> right) =>
            new Vector2<TScalar>(left) * right;

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
