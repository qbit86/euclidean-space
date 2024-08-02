namespace EuclideanSpace
{
    using System.Diagnostics;
    using System.Numerics;
    using System.Runtime.CompilerServices;

    public static class Vector2
    {
        private const int Count = 2;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TScalar Dot<TScalar>(Vector2<TScalar> left, Vector2<TScalar> right)
            where TScalar : IAdditionOperators<TScalar, TScalar, TScalar>,
            IMultiplyOperators<TScalar, TScalar, TScalar> => left.X * right.X + left.Y * right.Y;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static TScalar GetElement<TScalar>(this Vector2<TScalar> vector, int index)
            where TScalar : IAdditionOperators<TScalar, TScalar, TScalar>,
            IMultiplyOperators<TScalar, TScalar, TScalar>
        {
            ThrowHelpers.ThrowIfGreaterThanOrEqual((uint)index, (uint)Count);

            return vector.GetElementUnsafe(index);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static TScalar GetElementUnsafe<TScalar>(in this Vector2<TScalar> vector, int index)
            where TScalar : IAdditionOperators<TScalar, TScalar, TScalar>,
            IMultiplyOperators<TScalar, TScalar, TScalar>
        {
            Debug.Assert(index is >= 0 and < Count);
            ref var address = ref Unsafe.AsRef(in vector._x);
            return Unsafe.Add(ref address, index);
        }
    }
}
