namespace EuclideanSpace
{
    using System.Numerics;
    using System.Runtime.CompilerServices;

    public static class Point2Conversions<TTarget>
        where TTarget : INumberBase<TTarget>
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point2<TTarget> AsPoint2<TScalar>(Point2<TScalar> point)
            where TScalar : INumberBase<TScalar>
            => new(TTarget.CreateChecked(point.X), TTarget.CreateChecked(point.Y));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point2<TTarget> AsPoint2<TScalar>(Vector2<TScalar> vector)
            where TScalar : INumberBase<TScalar>
            => new(TTarget.CreateChecked(vector.X), TTarget.CreateChecked(vector.Y));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2<TTarget> AsVector2<TScalar>(Point2<TScalar> point)
            where TScalar : INumberBase<TScalar>
            => new(TTarget.CreateChecked(point.X), TTarget.CreateChecked(point.Y));
    }
}
