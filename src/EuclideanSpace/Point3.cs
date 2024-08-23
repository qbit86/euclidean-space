namespace EuclideanSpace
{
    using System;
    using System.Numerics;
    using System.Runtime.CompilerServices;

    public static partial class Point3
    {
        internal const int Count = Vector3.Count;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point3<TScalar> Create<TScalar>(TScalar value)
            where TScalar : IAdditionOperators<TScalar, TScalar, TScalar>,
            IMultiplyOperators<TScalar, TScalar, TScalar>,
            ISubtractionOperators<TScalar, TScalar, TScalar>,
            IUnaryNegationOperators<TScalar, TScalar>,
            IDivisionOperators<TScalar, TScalar, TScalar>
            => new(value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point3<TScalar> Create<TScalar>(TScalar x, TScalar y, TScalar z)
            where TScalar : IAdditionOperators<TScalar, TScalar, TScalar>,
            IMultiplyOperators<TScalar, TScalar, TScalar>,
            ISubtractionOperators<TScalar, TScalar, TScalar>,
            IUnaryNegationOperators<TScalar, TScalar>,
            IDivisionOperators<TScalar, TScalar, TScalar>
            => new(x, y, z);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point3<TScalar> Create<TScalar>(ReadOnlySpan<TScalar> elements)
            where TScalar : IAdditionOperators<TScalar, TScalar, TScalar>,
            IMultiplyOperators<TScalar, TScalar, TScalar>,
            ISubtractionOperators<TScalar, TScalar, TScalar>,
            IUnaryNegationOperators<TScalar, TScalar>,
            IDivisionOperators<TScalar, TScalar, TScalar>
        {
            if (elements.Length < Count)
                ThrowHelpers.ThrowArgumentOutOfRangeException(nameof(elements));

            return new(elements[0], elements[1], elements[2]);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point3<TScalar> Create<TScalar>(Vector3<TScalar> vector)
            where TScalar : IAdditionOperators<TScalar, TScalar, TScalar>,
            IMultiplyOperators<TScalar, TScalar, TScalar>,
            ISubtractionOperators<TScalar, TScalar, TScalar>,
            IUnaryNegationOperators<TScalar, TScalar>,
            IDivisionOperators<TScalar, TScalar, TScalar>
            => new(vector.X, vector.Y, vector.Z);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point3<TScalar> Zero<TScalar>()
            where TScalar : IAdditionOperators<TScalar, TScalar, TScalar>,
            IMultiplyOperators<TScalar, TScalar, TScalar>,
            ISubtractionOperators<TScalar, TScalar, TScalar>,
            IUnaryNegationOperators<TScalar, TScalar>,
            IDivisionOperators<TScalar, TScalar, TScalar>,
            IAdditiveIdentity<TScalar, TScalar>
            => new(TScalar.AdditiveIdentity);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point3<TScalar> One<TScalar>()
            where TScalar : IAdditionOperators<TScalar, TScalar, TScalar>,
            IMultiplyOperators<TScalar, TScalar, TScalar>,
            ISubtractionOperators<TScalar, TScalar, TScalar>,
            IUnaryNegationOperators<TScalar, TScalar>,
            IDivisionOperators<TScalar, TScalar, TScalar>,
            IMultiplicativeIdentity<TScalar, TScalar>
            => new(TScalar.MultiplicativeIdentity);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point3<TScalar> UnitX<TScalar>()
            where TScalar : IAdditionOperators<TScalar, TScalar, TScalar>,
            IMultiplyOperators<TScalar, TScalar, TScalar>,
            ISubtractionOperators<TScalar, TScalar, TScalar>,
            IUnaryNegationOperators<TScalar, TScalar>,
            IDivisionOperators<TScalar, TScalar, TScalar>,
            IAdditiveIdentity<TScalar, TScalar>,
            IMultiplicativeIdentity<TScalar, TScalar>
            => new(TScalar.MultiplicativeIdentity, TScalar.AdditiveIdentity, TScalar.AdditiveIdentity);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point3<TScalar> UnitY<TScalar>()
            where TScalar : IAdditionOperators<TScalar, TScalar, TScalar>,
            IMultiplyOperators<TScalar, TScalar, TScalar>,
            ISubtractionOperators<TScalar, TScalar, TScalar>,
            IUnaryNegationOperators<TScalar, TScalar>,
            IDivisionOperators<TScalar, TScalar, TScalar>,
            IAdditiveIdentity<TScalar, TScalar>,
            IMultiplicativeIdentity<TScalar, TScalar>
            => new(TScalar.AdditiveIdentity, TScalar.MultiplicativeIdentity, TScalar.AdditiveIdentity);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point3<TScalar> UnitZ<TScalar>()
            where TScalar : IAdditionOperators<TScalar, TScalar, TScalar>,
            IMultiplyOperators<TScalar, TScalar, TScalar>,
            ISubtractionOperators<TScalar, TScalar, TScalar>,
            IUnaryNegationOperators<TScalar, TScalar>,
            IDivisionOperators<TScalar, TScalar, TScalar>,
            IAdditiveIdentity<TScalar, TScalar>,
            IMultiplicativeIdentity<TScalar, TScalar>
            => new(TScalar.AdditiveIdentity, TScalar.AdditiveIdentity, TScalar.MultiplicativeIdentity);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point3<TScalar> Add<TScalar>(Point3<TScalar> left, Vector3<TScalar> right)
            where TScalar : IAdditionOperators<TScalar, TScalar, TScalar>,
            IMultiplyOperators<TScalar, TScalar, TScalar>,
            ISubtractionOperators<TScalar, TScalar, TScalar>,
            IUnaryNegationOperators<TScalar, TScalar>,
            IDivisionOperators<TScalar, TScalar, TScalar>
            => left + right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3<TScalar> Subtract<TScalar>(Point3<TScalar> left, Point3<TScalar> right)
            where TScalar : IAdditionOperators<TScalar, TScalar, TScalar>,
            IMultiplyOperators<TScalar, TScalar, TScalar>,
            ISubtractionOperators<TScalar, TScalar, TScalar>,
            IUnaryNegationOperators<TScalar, TScalar>,
            IDivisionOperators<TScalar, TScalar, TScalar>
            => left - right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point3<TScalar> Subtract<TScalar>(Point3<TScalar> left, Vector3<TScalar> right)
            where TScalar : IAdditionOperators<TScalar, TScalar, TScalar>,
            IMultiplyOperators<TScalar, TScalar, TScalar>,
            ISubtractionOperators<TScalar, TScalar, TScalar>,
            IUnaryNegationOperators<TScalar, TScalar>,
            IDivisionOperators<TScalar, TScalar, TScalar>
            => left - right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TScalar DistanceSquared<TScalar>(Point3<TScalar> value1, Point3<TScalar> value2)
            where TScalar : IAdditionOperators<TScalar, TScalar, TScalar>,
            IMultiplyOperators<TScalar, TScalar, TScalar>,
            ISubtractionOperators<TScalar, TScalar, TScalar>,
            IUnaryNegationOperators<TScalar, TScalar>,
            IDivisionOperators<TScalar, TScalar, TScalar>
            => (value1 - value2).LengthSquared();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TScalar Distance<TScalar>(Point3<TScalar> value1, Point3<TScalar> value2)
            where TScalar : IAdditionOperators<TScalar, TScalar, TScalar>,
            IMultiplyOperators<TScalar, TScalar, TScalar>,
            ISubtractionOperators<TScalar, TScalar, TScalar>,
            IUnaryNegationOperators<TScalar, TScalar>,
            IDivisionOperators<TScalar, TScalar, TScalar>,
            IRootFunctions<TScalar>
            => (value1 - value2).Length();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point3<TScalar> Lerp<TScalar>(Point3<TScalar> value1, Point3<TScalar> value2, TScalar amount)
            where TScalar : IAdditionOperators<TScalar, TScalar, TScalar>,
            IMultiplyOperators<TScalar, TScalar, TScalar>,
            ISubtractionOperators<TScalar, TScalar, TScalar>,
            IUnaryNegationOperators<TScalar, TScalar>,
            IDivisionOperators<TScalar, TScalar, TScalar>,
            IMultiplicativeIdentity<TScalar, TScalar>
        {
            var combination = Vector3.Lerp(value1.AsVector3(), value2.AsVector3(), amount);
            return Create(combination);
        }
    }
}
