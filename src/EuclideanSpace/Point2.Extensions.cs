namespace EuclideanSpace
{
    using System.Diagnostics;
    using System.Numerics;
    using System.Runtime.CompilerServices;

    public static partial class Point2
    {
        /// <summary>Reinterprets a <see cref="Point2{T}" /> as a new <see cref="Vector2{T}" />.</summary>
        /// <param name="point">The point to reinterpret.</param>
        /// <typeparam name="TScalar">The type of the components of the point and the vector.</typeparam>
        /// <returns><paramref name="point" /> reinterpreted as a new <see cref="Vector2{T}" />.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2<TScalar> AsVector2<TScalar>(this Point2<TScalar> point)
            where TScalar : IAdditionOperators<TScalar, TScalar, TScalar>,
            IAdditiveIdentity<TScalar, TScalar>,
            IMultiplyOperators<TScalar, TScalar, TScalar>,
            ISubtractionOperators<TScalar, TScalar, TScalar>,
            IUnaryNegationOperators<TScalar, TScalar>,
            IDivisionOperators<TScalar, TScalar, TScalar>
            => new(point.X, point.Y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static TScalar GetElementUnsafe<TScalar>(in this Point2<TScalar> point, int index)
            where TScalar : IAdditionOperators<TScalar, TScalar, TScalar>,
            IAdditiveIdentity<TScalar, TScalar>,
            IMultiplyOperators<TScalar, TScalar, TScalar>,
            ISubtractionOperators<TScalar, TScalar, TScalar>,
            IUnaryNegationOperators<TScalar, TScalar>,
            IDivisionOperators<TScalar, TScalar, TScalar>
        {
            Debug.Assert(index is >= 0 and < Count);
            ref var address = ref Unsafe.AsRef(in point._x);
            return Unsafe.Add(ref address, index);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static TScalar GetElement<TScalar>(this Point2<TScalar> point, int index)
            where TScalar : IAdditionOperators<TScalar, TScalar, TScalar>,
            IAdditiveIdentity<TScalar, TScalar>,
            IMultiplyOperators<TScalar, TScalar, TScalar>,
            ISubtractionOperators<TScalar, TScalar, TScalar>,
            IUnaryNegationOperators<TScalar, TScalar>,
            IDivisionOperators<TScalar, TScalar, TScalar>
        {
            ThrowHelpers.ThrowIfGreaterThanOrEqual((uint)index, (uint)Count);

            return point.GetElementUnsafe(index);
        }
    }
}
