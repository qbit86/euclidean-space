namespace EuclideanSpace
{
    using System.Numerics;
    using System.Runtime.CompilerServices;

    /// <summary>
    /// Provides a collection of static methods for operating on generic vectors that perform type conversions.
    /// </summary>
    public static class Vector2Conversions
    {
        /// <summary>
        /// Performs a linear interpolation between two vectors, converting their components to <typeparamref name="TAmount" /> for intermediate calculations.
        /// </summary>
        /// <param name="value1">The first vector, which is intended to be the lower bound.</param>
        /// <param name="value2">The second vector, which is intended to be the upper bound.</param>
        /// <param name="amount">A value, intended to be between 0 and 1, that indicates the weight of the interpolation.</param>
        /// <typeparam name="TScalar">The type of the components of the vectors.</typeparam>
        /// <typeparam name="TAmount">The type of the weight of the interpolation.</typeparam>
        /// <returns>The interpolated vector.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2<TScalar> Lerp<TScalar, TAmount>(
            Vector2<TScalar> value1, Vector2<TScalar> value2, TAmount amount)
            where TScalar : INumberBase<TScalar>
            where TAmount : INumberBase<TAmount>
        {
            var weight1 = TAmount.One - amount;
            var first = Vector2Conversions<TAmount>.AsVector2(value1) * weight1;
            var second = Vector2Conversions<TAmount>.AsVector2(value2) * amount;
            return Vector2Conversions<TScalar>.AsVector2(first + second);
        }
    }
}
