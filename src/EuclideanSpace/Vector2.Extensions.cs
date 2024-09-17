namespace EuclideanSpace
{
    using System.Diagnostics;
    using System.Numerics;
    using System.Runtime.CompilerServices;

    public static partial class Vector2
    {
        /// <summary>Returns the length of a vector.</summary>
        /// <typeparam name="TScalar">The type of the components of the vector.</typeparam>
        /// <returns>The vector's length.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TScalar Length<TScalar>(this Vector2<TScalar> value)
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

        /// <summary>Returns a vector with the same direction as the specified vector, but with a length of one.</summary>
        /// <param name="value">The vector to normalize.</param>
        /// <returns>The normalized vector.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2<TScalar> Normalize<TScalar>(this Vector2<TScalar> value)
            where TScalar : IAdditionOperators<TScalar, TScalar, TScalar>,
            IMultiplyOperators<TScalar, TScalar, TScalar>,
            ISubtractionOperators<TScalar, TScalar, TScalar>,
            IUnaryNegationOperators<TScalar, TScalar>,
            IDivisionOperators<TScalar, TScalar, TScalar>,
            IRootFunctions<TScalar>
            => value / value.Length();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static TScalar GetElementUnsafe<TScalar>(in this Vector2<TScalar> vector, int index)
            where TScalar : IAdditionOperators<TScalar, TScalar, TScalar>,
            IAdditiveIdentity<TScalar, TScalar>,
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
        internal static TScalar GetElement<TScalar>(this Vector2<TScalar> vector, int index)
            where TScalar : IAdditionOperators<TScalar, TScalar, TScalar>,
            IAdditiveIdentity<TScalar, TScalar>,
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
