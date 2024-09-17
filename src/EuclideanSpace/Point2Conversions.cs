namespace EuclideanSpace
{
    using System.Numerics;
    using System.Runtime.CompilerServices;

    /// <summary>
    /// Provides a collection of static methods for operating on generic points that perform type conversions.
    /// </summary>
    public static class Point2Conversions
    {
        /// <summary>
        /// Performs a linear interpolation between two points, converting their components to <typeparamref name="TAmount" /> for intermediate calculations.
        /// </summary>
        /// <param name="value1">The first point, which is intended to be the lower bound.</param>
        /// <param name="value2">The second point, which is intended to be the upper bound.</param>
        /// <param name="amount">A value, intended to be between 0 and 1, that indicates the weight of the interpolation.</param>
        /// <typeparam name="TScalar">The type of the components of the points.</typeparam>
        /// <typeparam name="TAmount">The type of the weight of the interpolation.</typeparam>
        /// <returns>The interpolated point.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point2<TScalar> Lerp<TScalar, TAmount>(
            Point2<TScalar> value1, Point2<TScalar> value2, TAmount amount)
            where TScalar : INumberBase<TScalar>
            where TAmount : INumberBase<TAmount>
        {
            var combination = Vector2Conversions.Lerp(value1.AsVector2(), value2.AsVector2(), amount);
            return Point2.Create(combination);
        }
    }
}
