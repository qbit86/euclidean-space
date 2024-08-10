namespace EuclideanSpace
{
    using System.Numerics;
    using System.Runtime.CompilerServices;

    public static class Point3Conversions<TTarget>
        where TTarget : INumberBase<TTarget>
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point3<TTarget> Create<TScalar>(TScalar value)
            where TScalar : INumberBase<TScalar>
            => new(TTarget.CreateChecked(value));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point3<TTarget> Create<TX, TY, TZ>(TX x, TY y, TZ z)
            where TX : INumberBase<TX>
            where TY : INumberBase<TY>
            where TZ : INumberBase<TZ>
            => new(TTarget.CreateChecked(x), TTarget.CreateChecked(y), TTarget.CreateChecked(z));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point3<TTarget> AsPoint3<TScalar>(Point3<TScalar> point)
            where TScalar : INumberBase<TScalar>
            => new(TTarget.CreateChecked(point.X), TTarget.CreateChecked(point.Y), TTarget.CreateChecked(point.Z));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point3<TTarget> AsPoint3<TScalar>(Vector3<TScalar> vector)
            where TScalar : INumberBase<TScalar>
            => new(TTarget.CreateChecked(vector.X), TTarget.CreateChecked(vector.Y), TTarget.CreateChecked(vector.Z));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3<TTarget> AsVector3<TScalar>(Point3<TScalar> point)
            where TScalar : INumberBase<TScalar>
            => new(TTarget.CreateChecked(point.X), TTarget.CreateChecked(point.Y), TTarget.CreateChecked(point.Z));
    }
}
