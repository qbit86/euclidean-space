namespace EuclideanSpace
{
    using System;
    using System.Numerics;
    using System.Runtime.CompilerServices;

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

        public Vector3(TScalar value) : this(value, value, value) { }

        public Vector3(TScalar x, TScalar y, TScalar z)
        {
            _x = x;
            _y = y;
            _z = z;
        }

        public Vector3(ReadOnlySpan<TScalar> elements)
        {
            if (elements.Length < Vector3.Count)
                ThrowHelpers.ThrowArgumentOutOfRangeException(nameof(elements));

            _x = elements[0];
            _y = elements[1];
            _z = elements[2];
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
