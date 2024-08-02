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
        IEqualityOperators<Vector2<TScalar>, Vector2<TScalar>, bool>
        where TScalar : IAdditionOperators<TScalar, TScalar, TScalar>,
        IMultiplyOperators<TScalar, TScalar, TScalar>
    {
        internal readonly TScalar _x;
        private readonly TScalar _y;

        public Vector2(TScalar value) : this(value, value) { }

        public Vector2(TScalar x, TScalar y)
        {
            _x = x;
            _y = y;
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
    }
}
