namespace EuclideanSpace
{
    using System;
    using System.Numerics;
    using System.Runtime.CompilerServices;

    /// <summary>
    /// Provides a collection of static methods for creating, manipulating, and otherwise operating on generic vectors.
    /// </summary>
    public static partial class Vector3
    {
        /// <summary>
        /// Gets the number of components that are in a <see cref="Vector3{T}" />.
        /// </summary>
        public const int Count = 3;

        /// <summary>
        /// Creates a new <see cref="Vector3{T}" /> instance with all components initialized to the specified value.
        /// </summary>
        /// <param name="value">The value that all components will be initialized to.</param>
        /// <typeparam name="TScalar">The type of the components of the vector.</typeparam>
        /// <returns>A new <see cref="Vector3{T}" /> with all components initialized to <paramref name="value" />.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3<TScalar> Create<TScalar>(TScalar value)
            where TScalar : IAdditionOperators<TScalar, TScalar, TScalar>,
            IAdditiveIdentity<TScalar, TScalar>,
            IMultiplyOperators<TScalar, TScalar, TScalar>,
            ISubtractionOperators<TScalar, TScalar, TScalar>,
            IUnaryNegationOperators<TScalar, TScalar>,
            IDivisionOperators<TScalar, TScalar, TScalar>
            => new(value);

        /// <summary>
        /// Creates a new <see cref="Vector3{T}" /> instance with all components initialized to the specified values.
        /// </summary>
        /// <param name="x">The value to assign to the <see cref="Vector3{T}.X" /> component.</param>
        /// <param name="y">The value to assign to the <see cref="Vector3{T}.Y" /> component.</param>
        /// <param name="z">The value to assign to the <see cref="Vector3{T}.Z" /> component.</param>
        /// <typeparam name="TScalar">The type of the components of the vector.</typeparam>
        /// <returns>A new <see cref="Vector3{T}" /> with all components initialized to the specified values.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3<TScalar> Create<TScalar>(TScalar x, TScalar y, TScalar z)
            where TScalar : IAdditionOperators<TScalar, TScalar, TScalar>,
            IAdditiveIdentity<TScalar, TScalar>,
            IMultiplyOperators<TScalar, TScalar, TScalar>,
            ISubtractionOperators<TScalar, TScalar, TScalar>,
            IUnaryNegationOperators<TScalar, TScalar>,
            IDivisionOperators<TScalar, TScalar, TScalar>
            => new(x, y, z);

        /// <summary>
        /// Creates a new <see cref="Vector3{T}" /> from a given readonly span.
        /// </summary>
        /// <param name="values">The readonly span from which the vector is created.</param>
        /// <typeparam name="TScalar">The type of the components of the vector.</typeparam>
        /// <returns>A new <see cref="Vector3{T}" /> with its components set to the first <see cref="Vector3.Count" /> elements from <paramref name="values" />.</returns>
        /// <exception cref="ArgumentOutOfRangeException">The length of <paramref name="values" /> is less than <see cref="Vector3.Count" />.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3<TScalar> Create<TScalar>(ReadOnlySpan<TScalar> values)
            where TScalar : IAdditionOperators<TScalar, TScalar, TScalar>,
            IAdditiveIdentity<TScalar, TScalar>,
            IMultiplyOperators<TScalar, TScalar, TScalar>,
            ISubtractionOperators<TScalar, TScalar, TScalar>,
            IUnaryNegationOperators<TScalar, TScalar>,
            IDivisionOperators<TScalar, TScalar, TScalar>
        {
            if (values.Length < Count)
                ThrowHelpers.ThrowArgumentOutOfRangeException(nameof(values));

            return new(values[0], values[1], values[2]);
        }

        /// <summary>Gets a vector whose components are equal to zero.</summary>
        /// <typeparam name="TScalar">The type of the components of the vector.</typeparam>
        /// <value>A vector whose components are equal to zero.</value>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3<TScalar> Zero<TScalar>()
            where TScalar : IAdditionOperators<TScalar, TScalar, TScalar>,
            IMultiplyOperators<TScalar, TScalar, TScalar>,
            ISubtractionOperators<TScalar, TScalar, TScalar>,
            IUnaryNegationOperators<TScalar, TScalar>,
            IDivisionOperators<TScalar, TScalar, TScalar>,
            IAdditiveIdentity<TScalar, TScalar>
            => new(TScalar.AdditiveIdentity);

        /// <summary>Gets a vector whose components are equal to one.</summary>
        /// <typeparam name="TScalar">The type of the components of the vector.</typeparam>
        /// <value>A vector whose components are equal to one.</value>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3<TScalar> One<TScalar>()
            where TScalar : IAdditionOperators<TScalar, TScalar, TScalar>,
            IAdditiveIdentity<TScalar, TScalar>,
            IMultiplyOperators<TScalar, TScalar, TScalar>,
            ISubtractionOperators<TScalar, TScalar, TScalar>,
            IUnaryNegationOperators<TScalar, TScalar>,
            IDivisionOperators<TScalar, TScalar, TScalar>,
            IMultiplicativeIdentity<TScalar, TScalar>
            => new(TScalar.MultiplicativeIdentity);

        /// <summary>Gets the vector (1,0,0).</summary>
        /// <typeparam name="TScalar">The type of the components of the vector.</typeparam>
        /// <returns>The vector <c>(1,0,0)</c>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3<TScalar> UnitX<TScalar>()
            where TScalar : IAdditionOperators<TScalar, TScalar, TScalar>,
            IMultiplyOperators<TScalar, TScalar, TScalar>,
            ISubtractionOperators<TScalar, TScalar, TScalar>,
            IUnaryNegationOperators<TScalar, TScalar>,
            IDivisionOperators<TScalar, TScalar, TScalar>,
            IAdditiveIdentity<TScalar, TScalar>,
            IMultiplicativeIdentity<TScalar, TScalar>
            => new(TScalar.MultiplicativeIdentity, TScalar.AdditiveIdentity, TScalar.AdditiveIdentity);

        /// <summary>Gets the vector (0,1,0).</summary>
        /// <typeparam name="TScalar">The type of the components of the vector.</typeparam>
        /// <returns>The vector <c>(0,1,0)</c>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3<TScalar> UnitY<TScalar>()
            where TScalar : IAdditionOperators<TScalar, TScalar, TScalar>,
            IMultiplyOperators<TScalar, TScalar, TScalar>,
            ISubtractionOperators<TScalar, TScalar, TScalar>,
            IUnaryNegationOperators<TScalar, TScalar>,
            IDivisionOperators<TScalar, TScalar, TScalar>,
            IAdditiveIdentity<TScalar, TScalar>,
            IMultiplicativeIdentity<TScalar, TScalar>
            => new(TScalar.AdditiveIdentity, TScalar.MultiplicativeIdentity, TScalar.AdditiveIdentity);

        /// <summary>Gets the vector (0,0,1).</summary>
        /// <typeparam name="TScalar">The type of the components of the vector.</typeparam>
        /// <returns>The vector <c>(0,0,1)</c>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3<TScalar> UnitZ<TScalar>()
            where TScalar : IAdditionOperators<TScalar, TScalar, TScalar>,
            IMultiplyOperators<TScalar, TScalar, TScalar>,
            ISubtractionOperators<TScalar, TScalar, TScalar>,
            IUnaryNegationOperators<TScalar, TScalar>,
            IDivisionOperators<TScalar, TScalar, TScalar>,
            IAdditiveIdentity<TScalar, TScalar>,
            IMultiplicativeIdentity<TScalar, TScalar>
            => new(TScalar.AdditiveIdentity, TScalar.AdditiveIdentity, TScalar.MultiplicativeIdentity);

        /// <summary>Adds two vectors to compute their sum.</summary>
        /// <param name="left">The vector to add with <paramref name="right" />.</param>
        /// <param name="right">The vector to add with <paramref name="left" />.</param>
        /// <typeparam name="TScalar">The type of the components of the vector.</typeparam>
        /// <returns>The sum of <paramref name="left" /> and <paramref name="right" />.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3<TScalar> Add<TScalar>(Vector3<TScalar> left, Vector3<TScalar> right)
            where TScalar : IAdditionOperators<TScalar, TScalar, TScalar>,
            IAdditiveIdentity<TScalar, TScalar>,
            IMultiplyOperators<TScalar, TScalar, TScalar>,
            ISubtractionOperators<TScalar, TScalar, TScalar>,
            IUnaryNegationOperators<TScalar, TScalar>,
            IDivisionOperators<TScalar, TScalar, TScalar>
            => left + right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3<TScalar> Multiply<TScalar>(Vector3<TScalar> left, Vector3<TScalar> right)
            where TScalar : IAdditionOperators<TScalar, TScalar, TScalar>,
            IAdditiveIdentity<TScalar, TScalar>,
            IMultiplyOperators<TScalar, TScalar, TScalar>,
            ISubtractionOperators<TScalar, TScalar, TScalar>,
            IUnaryNegationOperators<TScalar, TScalar>,
            IDivisionOperators<TScalar, TScalar, TScalar>
            => left * right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3<TScalar> Multiply<TScalar>(Vector3<TScalar> left, TScalar right)
            where TScalar : IAdditionOperators<TScalar, TScalar, TScalar>,
            IAdditiveIdentity<TScalar, TScalar>,
            IMultiplyOperators<TScalar, TScalar, TScalar>,
            ISubtractionOperators<TScalar, TScalar, TScalar>,
            IUnaryNegationOperators<TScalar, TScalar>,
            IDivisionOperators<TScalar, TScalar, TScalar>
            => left * right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3<TScalar> Multiply<TScalar>(TScalar left, Vector3<TScalar> right)
            where TScalar : IAdditionOperators<TScalar, TScalar, TScalar>,
            IAdditiveIdentity<TScalar, TScalar>,
            IMultiplyOperators<TScalar, TScalar, TScalar>,
            ISubtractionOperators<TScalar, TScalar, TScalar>,
            IUnaryNegationOperators<TScalar, TScalar>,
            IDivisionOperators<TScalar, TScalar, TScalar>
            => left * right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3<TScalar> Subtract<TScalar>(Vector3<TScalar> left, Vector3<TScalar> right)
            where TScalar : IAdditionOperators<TScalar, TScalar, TScalar>,
            IAdditiveIdentity<TScalar, TScalar>,
            IMultiplyOperators<TScalar, TScalar, TScalar>,
            ISubtractionOperators<TScalar, TScalar, TScalar>,
            IUnaryNegationOperators<TScalar, TScalar>,
            IDivisionOperators<TScalar, TScalar, TScalar>
            => left - right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3<TScalar> Negate<TScalar>(Vector3<TScalar> value)
            where TScalar : IAdditionOperators<TScalar, TScalar, TScalar>,
            IAdditiveIdentity<TScalar, TScalar>,
            IMultiplyOperators<TScalar, TScalar, TScalar>,
            ISubtractionOperators<TScalar, TScalar, TScalar>,
            IUnaryNegationOperators<TScalar, TScalar>,
            IDivisionOperators<TScalar, TScalar, TScalar>
            => -value;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3<TScalar> Divide<TScalar>(Vector3<TScalar> left, Vector3<TScalar> right)
            where TScalar : IAdditionOperators<TScalar, TScalar, TScalar>,
            IAdditiveIdentity<TScalar, TScalar>,
            IMultiplyOperators<TScalar, TScalar, TScalar>,
            ISubtractionOperators<TScalar, TScalar, TScalar>,
            IUnaryNegationOperators<TScalar, TScalar>,
            IDivisionOperators<TScalar, TScalar, TScalar>
            => left / right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3<TScalar> Divide<TScalar>(Vector3<TScalar> left, TScalar right)
            where TScalar : IAdditionOperators<TScalar, TScalar, TScalar>,
            IAdditiveIdentity<TScalar, TScalar>,
            IMultiplyOperators<TScalar, TScalar, TScalar>,
            ISubtractionOperators<TScalar, TScalar, TScalar>,
            IUnaryNegationOperators<TScalar, TScalar>,
            IDivisionOperators<TScalar, TScalar, TScalar>
            => left / right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TScalar Dot<TScalar>(Vector3<TScalar> left, Vector3<TScalar> right)
            where TScalar : IAdditionOperators<TScalar, TScalar, TScalar>,
            IAdditiveIdentity<TScalar, TScalar>,
            IMultiplyOperators<TScalar, TScalar, TScalar>,
            ISubtractionOperators<TScalar, TScalar, TScalar>,
            IUnaryNegationOperators<TScalar, TScalar>,
            IDivisionOperators<TScalar, TScalar, TScalar>
            => left.X * right.X + left.Y * right.Y + left.Z * right.Z;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3<TScalar> Cross<TScalar>(Vector3<TScalar> left, Vector3<TScalar> right)
            where TScalar : IAdditionOperators<TScalar, TScalar, TScalar>,
            IAdditiveIdentity<TScalar, TScalar>,
            IMultiplyOperators<TScalar, TScalar, TScalar>,
            ISubtractionOperators<TScalar, TScalar, TScalar>,
            IUnaryNegationOperators<TScalar, TScalar>,
            IDivisionOperators<TScalar, TScalar, TScalar>
            => new(
                left.Y * right.Z - left.Z * right.Y,
                left.Z * right.X - left.X * right.Z,
                left.X * right.Y - left.Y * right.X);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TScalar DistanceSquared<TScalar>(Vector3<TScalar> value1, Vector3<TScalar> value2)
            where TScalar : IAdditionOperators<TScalar, TScalar, TScalar>,
            IAdditiveIdentity<TScalar, TScalar>,
            IMultiplyOperators<TScalar, TScalar, TScalar>,
            ISubtractionOperators<TScalar, TScalar, TScalar>,
            IUnaryNegationOperators<TScalar, TScalar>,
            IDivisionOperators<TScalar, TScalar, TScalar>
            => (value1 - value2).LengthSquared();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TScalar Distance<TScalar>(Vector3<TScalar> value1, Vector3<TScalar> value2)
            where TScalar : IAdditionOperators<TScalar, TScalar, TScalar>,
            IMultiplyOperators<TScalar, TScalar, TScalar>,
            ISubtractionOperators<TScalar, TScalar, TScalar>,
            IUnaryNegationOperators<TScalar, TScalar>,
            IDivisionOperators<TScalar, TScalar, TScalar>,
            IRootFunctions<TScalar>
            => (value1 - value2).Length();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3<TScalar> Lerp<TScalar>(Vector3<TScalar> value1, Vector3<TScalar> value2, TScalar amount)
            where TScalar : IAdditionOperators<TScalar, TScalar, TScalar>,
            IAdditiveIdentity<TScalar, TScalar>,
            IMultiplyOperators<TScalar, TScalar, TScalar>,
            ISubtractionOperators<TScalar, TScalar, TScalar>,
            IUnaryNegationOperators<TScalar, TScalar>,
            IDivisionOperators<TScalar, TScalar, TScalar>,
            IMultiplicativeIdentity<TScalar, TScalar>
        {
            var weight1 = TScalar.MultiplicativeIdentity - amount;
            return value1 * weight1 + value2 * amount;
        }
    }
}
