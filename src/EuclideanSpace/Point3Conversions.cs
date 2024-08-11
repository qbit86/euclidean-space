namespace EuclideanSpace
{
    using System.Numerics;
    using System.Runtime.CompilerServices;

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
