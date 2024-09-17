namespace EuclideanSpace
{
    using System.Numerics;
    using System.Runtime.CompilerServices;

    /// <summary>
    /// Provides a collection of static methods for operating on generic vectors that perform type conversions.
    /// </summary>
    /// <typeparam name="TTarget">The type of the components in the output vector.</typeparam>
    public static class Vector2Conversions<TTarget>
        where TTarget : INumberBase<TTarget>
    {
        /// <summary>
        /// Creates a new <see cref="Vector2{T}" /> instance with all components initialized to the specified value converted to <typeparamref name="TTarget" />.
        /// </summary>
        /// <param name="value">The value to which all components will be initialized after conversion to <typeparamref name="TTarget" />.</param>
        /// <typeparam name="TScalar">The type of the components of the vector.</typeparam>
        /// <returns>A new <see cref="Vector2{T}" /> with all components initialized to <paramref name="value" /> converted to <typeparamref name="TTarget" />.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2<TTarget> Create<TScalar>(TScalar value)
            where TScalar : INumberBase<TScalar>
            => new(TTarget.CreateChecked(value));

        /// <summary>
        /// Creates a new <see cref="Vector2{T}" /> instance with all components initialized to the specified values converted to <typeparamref name="TTarget" />.
        /// </summary>
        /// <param name="x">The value to assign to the <see cref="Vector2{T}.X" /> component after conversion to <typeparamref name="TTarget" />.</param>
        /// <param name="y">The value to assign to the <see cref="Vector2{T}.Y" /> component after conversion to <typeparamref name="TTarget" />.</param>
        /// <typeparam name="TX">The type of the X component.</typeparam>
        /// <typeparam name="TY">The type of the Y component.</typeparam>
        /// <returns>A new <see cref="Vector2{T}" /> with all components initialized to the specified values converted to <typeparamref name="TTarget" />.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2<TTarget> Create<TX, TY>(TX x, TY y)
            where TX : INumberBase<TX>
            where TY : INumberBase<TY>
            => new(TTarget.CreateChecked(x), TTarget.CreateChecked(y));

        /// <summary>
        /// Creates a new <see langword="Vector2&lt;TTarget&gt;" /> instance with all components initialized to the components of the specified <paramref name="vector" /> converted to <typeparamref name="TTarget" />.
        /// </summary>
        /// <param name="vector">The vector whose components to convert to <typeparamref name="TTarget" />.</param>
        /// <typeparam name="TScalar">The type of the components of the input vector.</typeparam>
        /// <returns>A new <see langword="Vector2&lt;TTarget&gt;" /> with all components initialized to the components of <paramref name="vector" /> converted to <typeparamref name="TTarget" />.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2<TTarget> AsVector2<TScalar>(Vector2<TScalar> vector)
            where TScalar : INumberBase<TScalar>
            => new(TTarget.CreateChecked(vector.X), TTarget.CreateChecked(vector.Y));
    }
}
