namespace EuclideanSpace
{
    using System.Numerics;
    using System.Runtime.CompilerServices;

    /// <summary>
    /// Provides a collection of static methods for operating on generic points that perform type conversions.
    /// </summary>
    public static class Point3Conversions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point3<TScalar> Lerp<TScalar, TAmount>(
            Point3<TScalar> value1, Point3<TScalar> value2, TAmount amount)
            where TScalar : INumberBase<TScalar>
            where TAmount : INumberBase<TAmount>
        {
            var combination = Vector3Conversions.Lerp(value1.AsVector3(), value2.AsVector3(), amount);
            return Point3.Create(combination);
        }
    }
}
