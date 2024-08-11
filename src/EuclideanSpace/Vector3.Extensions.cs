namespace EuclideanSpace
{
    using System.Diagnostics;
    using System.Numerics;
    using System.Runtime.CompilerServices;

    public static partial class Vector3
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TScalar Length<TScalar>(this Vector3<TScalar> value)
            where TScalar : IAdditionOperators<TScalar, TScalar, TScalar>,
            IMultiplyOperators<TScalar, TScalar, TScalar>,
            ISubtractionOperators<TScalar, TScalar, TScalar>,
            IUnaryNegationOperators<TScalar, TScalar>,
            IDivisionOperators<TScalar, TScalar, TScalar>,
            IRootFunctions<TScalar>
        {
            var lengthSquared = value.LengthSquared();
            return TScalar.Sqrt(lengthSquared);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3<TScalar> Normalize<TScalar>(this Vector3<TScalar> value)
            where TScalar : IAdditionOperators<TScalar, TScalar, TScalar>,
            IMultiplyOperators<TScalar, TScalar, TScalar>,
            ISubtractionOperators<TScalar, TScalar, TScalar>,
            IUnaryNegationOperators<TScalar, TScalar>,
            IDivisionOperators<TScalar, TScalar, TScalar>,
            IRootFunctions<TScalar>
            => value / value.Length();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static TScalar GetElementUnsafe<TScalar>(in this Vector3<TScalar> vector, int index)
            where TScalar : IAdditionOperators<TScalar, TScalar, TScalar>,
            IMultiplyOperators<TScalar, TScalar, TScalar>,
            ISubtractionOperators<TScalar, TScalar, TScalar>,
            IUnaryNegationOperators<TScalar, TScalar>,
            IDivisionOperators<TScalar, TScalar, TScalar>
        {
            Debug.Assert(index is >= 0 and < Count);
            ref var address = ref Unsafe.AsRef(in vector._x);
            return Unsafe.Add(ref address, index);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static TScalar GetElement<TScalar>(this Vector3<TScalar> vector, int index)
            where TScalar : IAdditionOperators<TScalar, TScalar, TScalar>,
            IMultiplyOperators<TScalar, TScalar, TScalar>,
            ISubtractionOperators<TScalar, TScalar, TScalar>,
            IUnaryNegationOperators<TScalar, TScalar>,
            IDivisionOperators<TScalar, TScalar, TScalar>
        {
            ThrowHelpers.ThrowIfGreaterThanOrEqual((uint)index, (uint)Count);

            return vector.GetElementUnsafe(index);
        }
    }
}
