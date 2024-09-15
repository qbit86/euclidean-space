namespace EuclideanSpace
{
    using System.Numerics;
    using System.Runtime.CompilerServices;

    /// <summary>
    /// Provides a collection of static methods for operating on generic points that perform type conversions.
    /// </summary>
    /// <typeparam name="TTarget">The type of the components in the output point.</typeparam>
    public static class Point2Conversions<TTarget>
        where TTarget : INumberBase<TTarget>
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point2<TTarget> Create<TScalar>(TScalar value)
            where TScalar : INumberBase<TScalar>
            => new(TTarget.CreateChecked(value));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point2<TTarget> Create<TX, TY>(TX x, TY y)
            where TX : INumberBase<TX>
            where TY : INumberBase<TY>
            => new(TTarget.CreateChecked(x), TTarget.CreateChecked(y));

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
