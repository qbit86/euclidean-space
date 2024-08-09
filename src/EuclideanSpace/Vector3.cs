namespace EuclideanSpace
{
    using System.Numerics;
    using System.Runtime.CompilerServices;

    public static partial class Vector3
    {
        internal const int Count = 3;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TScalar Dot<TScalar>(Vector3<TScalar> left, Vector3<TScalar> right)
            where TScalar : IAdditionOperators<TScalar, TScalar, TScalar>,
            IMultiplyOperators<TScalar, TScalar, TScalar>,
            ISubtractionOperators<TScalar, TScalar, TScalar>,
            IUnaryNegationOperators<TScalar, TScalar>,
            IDivisionOperators<TScalar, TScalar, TScalar>
            => left.X * right.X + left.Y * right.Y + left.Z * right.Z;
    }
}
