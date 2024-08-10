namespace EuclideanSpace
{
    using System;
    using System.Numerics;

    public readonly partial struct Point3<TScalar>
        where TScalar : IAdditionOperators<TScalar, TScalar, TScalar>,
        IMultiplyOperators<TScalar, TScalar, TScalar>,
        ISubtractionOperators<TScalar, TScalar, TScalar>,
        IUnaryNegationOperators<TScalar, TScalar>,
        IDivisionOperators<TScalar, TScalar, TScalar>
    {
        internal readonly TScalar _x;
        private readonly TScalar _y;
        private readonly TScalar _z;

        public Point3(TScalar x, TScalar y, TScalar z)
        {
            _x = x;
            _y = y;
            _z = z;
        }

        public Point3(ReadOnlySpan<TScalar> elements)
        {
            if (elements.Length < Point2.Count)
                ThrowHelpers.ThrowArgumentOutOfRangeException(nameof(elements));

            _x = elements[0];
            _y = elements[1];
            _z = elements[2];
        }

        public TScalar X => _x;

        public TScalar Y => _y;

        public TScalar Z => _z;
    }
}
