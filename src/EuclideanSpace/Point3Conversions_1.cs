namespace EuclideanSpace
{
    using System.Numerics;
    using System.Runtime.CompilerServices;

    /// <summary>
    /// Provides a collection of static methods for operating on generic points that perform type conversions.
    /// </summary>
    /// <typeparam name="TTarget">The type of the components in the output point.</typeparam>
    public static class Point3Conversions<TTarget>
        where TTarget : INumberBase<TTarget>
    {
        /// <summary>
        /// Creates a new <see cref="Point3{T}" /> instance with all components initialized to the specified value converted to <typeparamref name="TTarget" />.
        /// </summary>
        /// <param name="value">The value to which all components will be initialized after conversion to <typeparamref name="TTarget" />.</param>
        /// <typeparam name="TScalar">The type of the components of the point.</typeparam>
        /// <returns>A new <see cref="Point3{T}" /> with all components initialized to <paramref name="value" /> converted to <typeparamref name="TTarget" />.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point3<TTarget> Create<TScalar>(TScalar value)
            where TScalar : INumberBase<TScalar>
            => new(TTarget.CreateChecked(value));

        /// <summary>
        /// Creates a new <see cref="Point3{T}" /> instance with all components initialized to the specified values converted to <typeparamref name="TTarget" />.
        /// </summary>
        /// <param name="x">The value to assign to the <see cref="Point3{T}.X" /> component after conversion to <typeparamref name="TTarget" />.</param>
        /// <param name="y">The value to assign to the <see cref="Point3{T}.Y" /> component after conversion to <typeparamref name="TTarget" />.</param>
        /// <param name="z">The value to assign to the <see cref="Point3{T}.Z" /> component after conversion to <typeparamref name="TTarget" />.</param>
        /// <typeparam name="TX">The type of the X component.</typeparam>
        /// <typeparam name="TY">The type of the Y component.</typeparam>
        /// <typeparam name="TZ">The type of the Z component.</typeparam>
        /// <returns>A new <see cref="Point3{T}" /> with all components initialized to the specified values converted to <typeparamref name="TTarget" />.</returns>
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
