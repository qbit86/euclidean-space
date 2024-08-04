namespace EuclideanSpace
{
    using System;
    using System.Numerics;

    public readonly partial struct Point2<TScalar> :
        IEquatable<Point2<TScalar>>,
        IFormattable,
        IEqualityOperators<Point2<TScalar>, Point2<TScalar>, bool>
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
            if (elements.Length < Vector2.Count)
                ThrowHelpers.ThrowArgumentOutOfRangeException(nameof(elements));

            _x = elements[0];
            _y = elements[1];
        }

        public TScalar X => _x;

        public TScalar Y => _y;
    }
}
