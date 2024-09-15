namespace EuclideanSpace
{
    using System.Numerics;
    using System.Runtime.CompilerServices;

    /// <summary>
    /// Provides a collection of static methods for operating on generic vectors that perform type conversions.
    /// </summary>
    public static class Vector3Conversions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3<TScalar> Lerp<TScalar, TAmount>(
            Vector3<TScalar> value1, Vector3<TScalar> value2, TAmount amount)
            where TScalar : INumberBase<TScalar>
            where TAmount : INumberBase<TAmount>
        {
            var weight1 = TAmount.One - amount;
            var first = Vector3Conversions<TAmount>.AsVector3(value1) * weight1;
            var second = Vector3Conversions<TAmount>.AsVector3(value2) * amount;
            return Vector3Conversions<TScalar>.AsVector3(first + second);
        }
    }
}
