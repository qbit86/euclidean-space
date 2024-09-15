namespace EuclideanSpace
{
    using System.Numerics;
    using System.Runtime.CompilerServices;

    /// <summary>
    /// Provides a collection of static methods for operating on generic vectors that perform type conversions.
    /// </summary>
    public static class Vector2Conversions
    {
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
