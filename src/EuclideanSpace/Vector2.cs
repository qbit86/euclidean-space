namespace EuclideanSpace
{
    using System;
    using System.Numerics;
    using System.Runtime.CompilerServices;

    /// <summary>
    /// Provides a collection of static methods for creating, manipulating, and otherwise operating on generic vectors.
    /// </summary>
    public static partial class Vector2
    {
        /// <summary>
        /// Gets the number of components that are in a <see cref="Vector2{T}" />.
        /// </summary>
        public const int Count = 2;

        /// <summary>
        /// Creates a new <see cref="Vector2{T}" /> instance with all components initialized to the specified value.
        /// </summary>
        /// <param name="value">The value that all components will be initialized to.</param>
        /// <typeparam name="TScalar">The type of the components of the vector.</typeparam>
        /// <returns>A new <see cref="Vector2{T}" /> with all components initialized to <paramref name="value" />.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2<TScalar> Create<TScalar>(TScalar value)
            where TScalar : IAdditionOperators<TScalar, TScalar, TScalar>,
            IAdditiveIdentity<TScalar, TScalar>,
            IMultiplyOperators<TScalar, TScalar, TScalar>,
            ISubtractionOperators<TScalar, TScalar, TScalar>,
            IUnaryNegationOperators<TScalar, TScalar>,
            IDivisionOperators<TScalar, TScalar, TScalar>
            => new(value);

        /// <summary>
        /// Creates a new <see cref="Vector2{T}" /> instance with all components initialized to the specified values.
        /// </summary>
        /// <param name="x">The value to assign to the <see cref="Vector2{T}.X" /> component.</param>
        /// <param name="y">The value to assign to the <see cref="Vector2{T}.Y" /> component.</param>
        /// <typeparam name="TScalar">The type of the components of the vector.</typeparam>
        /// <returns>A new <see cref="Vector2{T}" /> with all components initialized to the specified values.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2<TScalar> Create<TScalar>(TScalar x, TScalar y)
            where TScalar : IAdditionOperators<TScalar, TScalar, TScalar>,
            IAdditiveIdentity<TScalar, TScalar>,
            IMultiplyOperators<TScalar, TScalar, TScalar>,
            ISubtractionOperators<TScalar, TScalar, TScalar>,
            IUnaryNegationOperators<TScalar, TScalar>,
            IDivisionOperators<TScalar, TScalar, TScalar>
            => new(x, y);

        /// <summary>
        /// Creates a new <see cref="Vector2{T}" /> from a given readonly span.
        /// </summary>
        /// <param name="values">The readonly span from which the vector is created.</param>
        /// <typeparam name="TScalar">The type of the components of the vector.</typeparam>
        /// <returns>A new <see cref="Vector2{T}" /> with its components set to the first <see cref="Vector2.Count" /> elements from <paramref name="values" />.</returns>
        /// <exception cref="ArgumentOutOfRangeException">The length of <paramref name="values" /> is less than <see cref="Vector2.Count" />.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2<TScalar> Create<TScalar>(ReadOnlySpan<TScalar> values)
            where TScalar : IAdditionOperators<TScalar, TScalar, TScalar>,
            IAdditiveIdentity<TScalar, TScalar>,
            IMultiplyOperators<TScalar, TScalar, TScalar>,
            ISubtractionOperators<TScalar, TScalar, TScalar>,
            IUnaryNegationOperators<TScalar, TScalar>,
            IDivisionOperators<TScalar, TScalar, TScalar>
        {
            if (values.Length < Count)
                ThrowHelpers.ThrowArgumentOutOfRangeException(nameof(values));

            return new(values[0], values[1]);
        }

        /// <summary>Gets a vector whose components are equal to zero.</summary>
        /// <typeparam name="TScalar">The type of the components of the vector.</typeparam>
        /// <returns>A vector whose components are equal to zero.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2<TScalar> Zero<TScalar>()
            where TScalar : IAdditionOperators<TScalar, TScalar, TScalar>,
            IMultiplyOperators<TScalar, TScalar, TScalar>,
            ISubtractionOperators<TScalar, TScalar, TScalar>,
            IUnaryNegationOperators<TScalar, TScalar>,
            IDivisionOperators<TScalar, TScalar, TScalar>,
            IAdditiveIdentity<TScalar, TScalar>
            => new(TScalar.AdditiveIdentity);

        /// <summary>Gets a vector whose components are equal to one.</summary>
        /// <typeparam name="TScalar">The type of the components of the vector.</typeparam>
        /// <returns>A vector whose components are equal to one.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2<TScalar> One<TScalar>()
            where TScalar : IAdditionOperators<TScalar, TScalar, TScalar>,
            IAdditiveIdentity<TScalar, TScalar>,
            IMultiplyOperators<TScalar, TScalar, TScalar>,
            ISubtractionOperators<TScalar, TScalar, TScalar>,
            IUnaryNegationOperators<TScalar, TScalar>,
            IDivisionOperators<TScalar, TScalar, TScalar>,
            IMultiplicativeIdentity<TScalar, TScalar>
            => new(TScalar.MultiplicativeIdentity);

        /// <summary>Gets the vector (1,0).</summary>
        /// <typeparam name="TScalar">The type of the components of the vector.</typeparam>
        /// <returns>The vector <c>(1,0)</c>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2<TScalar> UnitX<TScalar>()
            where TScalar : IAdditionOperators<TScalar, TScalar, TScalar>,
            IMultiplyOperators<TScalar, TScalar, TScalar>,
            ISubtractionOperators<TScalar, TScalar, TScalar>,
            IUnaryNegationOperators<TScalar, TScalar>,
            IDivisionOperators<TScalar, TScalar, TScalar>,
            IAdditiveIdentity<TScalar, TScalar>,
            IMultiplicativeIdentity<TScalar, TScalar>
            => new(TScalar.MultiplicativeIdentity, TScalar.AdditiveIdentity);

        /// <summary>Gets the vector (0,1).</summary>
        /// <typeparam name="TScalar">The type of the components of the vector.</typeparam>
        /// <returns>The vector <c>(0,1)</c>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2<TScalar> UnitY<TScalar>()
            where TScalar : IAdditionOperators<TScalar, TScalar, TScalar>,
            IMultiplyOperators<TScalar, TScalar, TScalar>,
            ISubtractionOperators<TScalar, TScalar, TScalar>,
            IUnaryNegationOperators<TScalar, TScalar>,
            IDivisionOperators<TScalar, TScalar, TScalar>,
            IAdditiveIdentity<TScalar, TScalar>,
            IMultiplicativeIdentity<TScalar, TScalar>
            => new(TScalar.AdditiveIdentity, TScalar.MultiplicativeIdentity);

        /// <summary>Adds two vectors to compute their sum.</summary>
        /// <param name="left">The vector to add with <paramref name="right" />.</param>
        /// <param name="right">The vector to add with <paramref name="left" />.</param>
        /// <typeparam name="TScalar">The type of the components of the vectors.</typeparam>
        /// <returns>The sum of <paramref name="left" /> and <paramref name="right" />.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2<TScalar> Add<TScalar>(Vector2<TScalar> left, Vector2<TScalar> right)
            where TScalar : IAdditionOperators<TScalar, TScalar, TScalar>,
            IAdditiveIdentity<TScalar, TScalar>,
            IMultiplyOperators<TScalar, TScalar, TScalar>,
            ISubtractionOperators<TScalar, TScalar, TScalar>,
            IUnaryNegationOperators<TScalar, TScalar>,
            IDivisionOperators<TScalar, TScalar, TScalar>
            => left + right;

        /// <summary>Multiplies two vectors to compute their component-wise product.</summary>
        /// <param name="left">The vector to multiply with <paramref name="right" />.</param>
        /// <param name="right">The vector to multiply with <paramref name="left" />.</param>
        /// <typeparam name="TScalar">The type of the components of the vectors.</typeparam>
        /// <returns>The component-wise product of <paramref name="left" /> and <paramref name="right" />.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2<TScalar> Multiply<TScalar>(Vector2<TScalar> left, Vector2<TScalar> right)
            where TScalar : IAdditionOperators<TScalar, TScalar, TScalar>,
            IAdditiveIdentity<TScalar, TScalar>,
            IMultiplyOperators<TScalar, TScalar, TScalar>,
            ISubtractionOperators<TScalar, TScalar, TScalar>,
            IUnaryNegationOperators<TScalar, TScalar>,
            IDivisionOperators<TScalar, TScalar, TScalar>
            => left * right;

        /// <summary>Multiplies a vector by a scalar to compute their product.</summary>
        /// <param name="left">The vector to multiply with <paramref name="right" />.</param>
        /// <param name="right">The scalar to multiply with <paramref name="left" />.</param>
        /// <typeparam name="TScalar">The type of the components of the vector.</typeparam>
        /// <returns>The product of <paramref name="left" /> and <paramref name="right" />.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2<TScalar> Multiply<TScalar>(Vector2<TScalar> left, TScalar right)
            where TScalar : IAdditionOperators<TScalar, TScalar, TScalar>,
            IAdditiveIdentity<TScalar, TScalar>,
            IMultiplyOperators<TScalar, TScalar, TScalar>,
            ISubtractionOperators<TScalar, TScalar, TScalar>,
            IUnaryNegationOperators<TScalar, TScalar>,
            IDivisionOperators<TScalar, TScalar, TScalar>
            => left * right;

        /// <summary>Multiplies a vector by a scalar to compute their product.</summary>
        /// <param name="left">The scalar to multiply with <paramref name="right" />.</param>
        /// <param name="right">The vector to multiply with <paramref name="left" />.</param>
        /// <typeparam name="TScalar">The type of the components of the vector.</typeparam>
        /// <returns>The product of <paramref name="left" /> and <paramref name="right" />.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2<TScalar> Multiply<TScalar>(TScalar left, Vector2<TScalar> right)
            where TScalar : IAdditionOperators<TScalar, TScalar, TScalar>,
            IAdditiveIdentity<TScalar, TScalar>,
            IMultiplyOperators<TScalar, TScalar, TScalar>,
            ISubtractionOperators<TScalar, TScalar, TScalar>,
            IUnaryNegationOperators<TScalar, TScalar>,
            IDivisionOperators<TScalar, TScalar, TScalar>
            => left * right;

        /// <summary>Subtracts two vectors to compute their difference.</summary>
        /// <param name="left">The vector from which <paramref name="right" /> will be subtracted.</param>
        /// <param name="right">The vector to subtract from <paramref name="left" />.</param>
        /// <typeparam name="TScalar">The type of the components of the vectors.</typeparam>
        /// <returns>The difference of <paramref name="left" /> and <paramref name="right" />.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2<TScalar> Subtract<TScalar>(Vector2<TScalar> left, Vector2<TScalar> right)
            where TScalar : IAdditionOperators<TScalar, TScalar, TScalar>,
            IAdditiveIdentity<TScalar, TScalar>,
            IMultiplyOperators<TScalar, TScalar, TScalar>,
            ISubtractionOperators<TScalar, TScalar, TScalar>,
            IUnaryNegationOperators<TScalar, TScalar>,
            IDivisionOperators<TScalar, TScalar, TScalar>
            => left - right;

        /// <summary>Computes the unary negation of a vector.</summary>
        /// <param name="value">The vector to negate.</param>
        /// <typeparam name="TScalar">The type of the components of the vector.</typeparam>
        /// <returns>A vector whose components are the unary negation of the corresponding components in <paramref name="value" />.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2<TScalar> Negate<TScalar>(Vector2<TScalar> value)
            where TScalar : IAdditionOperators<TScalar, TScalar, TScalar>,
            IAdditiveIdentity<TScalar, TScalar>,
            IMultiplyOperators<TScalar, TScalar, TScalar>,
            ISubtractionOperators<TScalar, TScalar, TScalar>,
            IUnaryNegationOperators<TScalar, TScalar>,
            IDivisionOperators<TScalar, TScalar, TScalar>
            => -value;

        /// <summary>Divides two vectors to compute their quotient.</summary>
        /// <param name="left">The vector that will be divided by <paramref name="right" />.</param>
        /// <param name="right">The vector that will divide <paramref name="left" />.</param>
        /// <typeparam name="TScalar">The type of the components of the vectors.</typeparam>
        /// <returns>The quotient of <paramref name="left" /> divided by <paramref name="right" />.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2<TScalar> Divide<TScalar>(Vector2<TScalar> left, Vector2<TScalar> right)
            where TScalar : IAdditionOperators<TScalar, TScalar, TScalar>,
            IAdditiveIdentity<TScalar, TScalar>,
            IMultiplyOperators<TScalar, TScalar, TScalar>,
            ISubtractionOperators<TScalar, TScalar, TScalar>,
            IUnaryNegationOperators<TScalar, TScalar>,
            IDivisionOperators<TScalar, TScalar, TScalar>
            => left / right;

        /// <summary>Divides a vector by a scalar to compute the per-component quotient.</summary>
        /// <param name="left">The vector that will be divided by <paramref name="right" />.</param>
        /// <param name="right">The scalar that will divide <paramref name="left" />.</param>
        /// <typeparam name="TScalar">The type of the components of the vector.</typeparam>
        /// <returns>The quotient of <paramref name="left" /> divided by <paramref name="right" />.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2<TScalar> Divide<TScalar>(Vector2<TScalar> left, TScalar right)
            where TScalar : IAdditionOperators<TScalar, TScalar, TScalar>,
            IAdditiveIdentity<TScalar, TScalar>,
            IMultiplyOperators<TScalar, TScalar, TScalar>,
            ISubtractionOperators<TScalar, TScalar, TScalar>,
            IUnaryNegationOperators<TScalar, TScalar>,
            IDivisionOperators<TScalar, TScalar, TScalar>
            => left / right;

        /// <summary>Computes the dot product of two vectors.</summary>
        /// <param name="left">The vector that will be dotted with <paramref name="right" />.</param>
        /// <param name="right">The vector that will be dotted with <paramref name="left" />.</param>
        /// <typeparam name="TScalar">The type of the components of the vectors.</typeparam>
        /// <returns>The dot product of <paramref name="left" /> and <paramref name="right" />.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TScalar Dot<TScalar>(Vector2<TScalar> left, Vector2<TScalar> right)
            where TScalar : IAdditionOperators<TScalar, TScalar, TScalar>,
            IAdditiveIdentity<TScalar, TScalar>,
            IMultiplyOperators<TScalar, TScalar, TScalar>,
            ISubtractionOperators<TScalar, TScalar, TScalar>,
            IUnaryNegationOperators<TScalar, TScalar>,
            IDivisionOperators<TScalar, TScalar, TScalar>
            => left.X * right.X + left.Y * right.Y;

        /// <summary>Computes the pseudo-scalar product of two vectors.</summary>
        /// <param name="left">The first vector.</param>
        /// <param name="right">The second vector.</param>
        /// <typeparam name="TScalar">The type of the components of the vectors.</typeparam>
        /// <returns>The pseudo-scalar product.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TScalar Cross<TScalar>(Vector2<TScalar> left, Vector2<TScalar> right)
            where TScalar : IAdditionOperators<TScalar, TScalar, TScalar>,
            IAdditiveIdentity<TScalar, TScalar>,
            IMultiplyOperators<TScalar, TScalar, TScalar>,
            ISubtractionOperators<TScalar, TScalar, TScalar>,
            IUnaryNegationOperators<TScalar, TScalar>,
            IDivisionOperators<TScalar, TScalar, TScalar>
            => left.X * right.Y - left.Y * right.X;

        /// <summary>Returns the Euclidean distance squared between the endpoints of two specified vectors.</summary>
        /// <param name="value1">The first vector.</param>
        /// <param name="value2">The second vector.</param>
        /// <typeparam name="TScalar">The type of the components of the vectors.</typeparam>
        /// <returns>The distance squared.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TScalar DistanceSquared<TScalar>(Vector2<TScalar> value1, Vector2<TScalar> value2)
            where TScalar : IAdditionOperators<TScalar, TScalar, TScalar>,
            IAdditiveIdentity<TScalar, TScalar>,
            IMultiplyOperators<TScalar, TScalar, TScalar>,
            ISubtractionOperators<TScalar, TScalar, TScalar>,
            IUnaryNegationOperators<TScalar, TScalar>,
            IDivisionOperators<TScalar, TScalar, TScalar>
            => (value1 - value2).LengthSquared();

        /// <summary>Computes the Euclidean distance between the endpoints of two given vectors.</summary>
        /// <param name="value1">The first vector.</param>
        /// <param name="value2">The second vector.</param>
        /// <typeparam name="TScalar">The type of the components of the vector.</typeparam>
        /// <returns>The distance.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TScalar Distance<TScalar>(Vector2<TScalar> value1, Vector2<TScalar> value2)
            where TScalar : IAdditionOperators<TScalar, TScalar, TScalar>,
            IMultiplyOperators<TScalar, TScalar, TScalar>,
            ISubtractionOperators<TScalar, TScalar, TScalar>,
            IUnaryNegationOperators<TScalar, TScalar>,
            IDivisionOperators<TScalar, TScalar, TScalar>,
            IRootFunctions<TScalar>
            => (value1 - value2).Length();

        /// <summary>
        /// Performs a linear interpolation between two vectors based on the given weight.
        /// </summary>
        /// <param name="value1">The first vector, which is intended to be the lower bound.</param>
        /// <param name="value2">The second vector, which is intended to be the upper bound.</param>
        /// <param name="amount">A value, intended to be between 0 and 1, that indicates the weight of the interpolation.</param>
        /// <typeparam name="TScalar">The type of the components of the vectors.</typeparam>
        /// <returns>The interpolated vector.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2<TScalar> Lerp<TScalar>(Vector2<TScalar> value1, Vector2<TScalar> value2, TScalar amount)
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
