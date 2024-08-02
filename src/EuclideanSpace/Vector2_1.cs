namespace EuclideanSpace
{
    using System;

    /// <summary>
    /// Represents a vector with two components.
    /// </summary>
    /// <typeparam name="TScalar">The type of the scalar.</typeparam>
    public readonly partial struct Vector2<TScalar> : IEquatable<Vector2<TScalar>>, IFormattable
    {
        private readonly TScalar _x;
        private readonly TScalar _y;

        public Vector2(TScalar value) : this(value, value) { }

        public Vector2(TScalar x, TScalar y)
        {
            _x = x;
            _y = y;
        }
    }
}
