namespace EuclideanSpace
{
    using System.Numerics;
    using System.Runtime.CompilerServices;

    public static class Point2Conversions
    {
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
