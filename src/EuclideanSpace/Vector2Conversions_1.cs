namespace EuclideanSpace
{
    using System.Numerics;
    using System.Runtime.CompilerServices;

    public static class Vector2Conversions<TTarget>
        where TTarget : INumberBase<TTarget>
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2<TTarget> Create<TScalar>(TScalar value)
            where TScalar : INumberBase<TScalar>
            => new(TTarget.CreateChecked(value));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2<TTarget> Create<TX, TY>(TX x, TY y)
            where TX : INumberBase<TX>
            where TY : INumberBase<TY>
            => new(TTarget.CreateChecked(x), TTarget.CreateChecked(y));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2<TTarget> AsVector2<TScalar>(Vector2<TScalar> vector)
            where TScalar : INumberBase<TScalar>
            => new(TTarget.CreateChecked(vector.X), TTarget.CreateChecked(vector.Y));
    }
}
