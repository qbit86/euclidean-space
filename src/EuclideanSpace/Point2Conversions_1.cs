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
        /// <summary>
        /// Creates a new <see cref="Point2{T}" /> instance with all components initialized to the specified value converted to <typeparamref name="TTarget" />.
        /// </summary>
        /// <param name="value">The value to which all components will be initialized after conversion to <typeparamref name="TTarget" />.</param>
        /// <typeparam name="TScalar">The type of the components of the point.</typeparam>
        /// <returns>A new <see cref="Point2{T}" /> with all components initialized to <paramref name="value" /> converted to <typeparamref name="TTarget" />.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point2<TTarget> Create<TScalar>(TScalar value)
            where TScalar : INumberBase<TScalar>
            => new(TTarget.CreateChecked(value));

        /// <summary>
        /// Creates a new <see cref="Point2{T}" /> instance with all components initialized to the specified values converted to <typeparamref name="TTarget" />.
        /// </summary>
        /// <param name="x">The value to assign to the <see cref="Point2{T}.X" /> component after conversion to <typeparamref name="TTarget" />.</param>
        /// <param name="y">The value to assign to the <see cref="Point2{T}.Y" /> component after conversion to <typeparamref name="TTarget" />.</param>
        /// <typeparam name="TX">The type of the X component.</typeparam>
        /// <typeparam name="TY">The type of the Y component.</typeparam>
        /// <returns>A new <see cref="Point2{T}" /> with all components initialized to the specified values converted to <typeparamref name="TTarget" />.</returns>
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
