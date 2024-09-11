namespace EuclideanSpace
{
    using System;
    using System.Numerics;
    using System.Runtime.CompilerServices;

    /// <summary>
    /// Provides a collection of static methods for creating, manipulating, and otherwise operating on generic points.
    /// </summary>
    public static partial class Point2
    {
        /// <summary>
        /// Gets the number of components that are in a <see cref="Point2{T}" />.
        /// </summary>
        public const int Count = Vector2.Count;

        /// <summary>
        /// Creates a new <see cref="Point2{T}" /> instance with all components initialized to the specified value.
        /// </summary>
        /// <param name="value">The value that all components will be initialized to.</param>
        /// <typeparam name="TScalar">The type of the components of the point.</typeparam>
        /// <returns>A new <see cref="Point2{T}" /> with all components initialized to <paramref name="value" />.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point2<TScalar> Create<TScalar>(TScalar value)
            where TScalar : IAdditionOperators<TScalar, TScalar, TScalar>,
            IAdditiveIdentity<TScalar, TScalar>,
            IMultiplyOperators<TScalar, TScalar, TScalar>,
            ISubtractionOperators<TScalar, TScalar, TScalar>,
            IUnaryNegationOperators<TScalar, TScalar>,
            IDivisionOperators<TScalar, TScalar, TScalar>
            => new(value);

        /// <summary>
        /// Creates a new <see cref="Point2{T}" /> instance with all components initialized to the specified values.
        /// </summary>
        /// <param name="x">The value to assign to the <see cref="Point2{T}.X" /> component.</param>
        /// <param name="y">The value to assign to the <see cref="Point2{T}.Y" /> component.</param>
        /// <typeparam name="TScalar">The type of the components of the point.</typeparam>
        /// <returns>A new <see cref="Point2{T}" /> with all components initialized to the specified values.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point2<TScalar> Create<TScalar>(TScalar x, TScalar y)
            where TScalar : IAdditionOperators<TScalar, TScalar, TScalar>,
            IAdditiveIdentity<TScalar, TScalar>,
            IMultiplyOperators<TScalar, TScalar, TScalar>,
            ISubtractionOperators<TScalar, TScalar, TScalar>,
            IUnaryNegationOperators<TScalar, TScalar>,
            IDivisionOperators<TScalar, TScalar, TScalar>
            => new(x, y);

        /// <summary>
        /// Creates a new <see cref="Point2{T}" /> from a given readonly span.
        /// </summary>
        /// <param name="values">The readonly span from which the point is created.</param>
        /// <typeparam name="TScalar">The type of the components of the point.</typeparam>
        /// <returns>A new <see cref="Point2{T}" /> with its components set to the first <see cref="Point2.Count" /> elements from <paramref name="values" />.</returns>
        /// <exception cref="ArgumentOutOfRangeException">The length of <paramref name="values" /> is less than <see cref="Point2.Count" />.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point2<TScalar> Create<TScalar>(ReadOnlySpan<TScalar> values)
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

        /// <summary>
        /// Creates a new <see cref="Point2{T}" /> from a given vector.
        /// </summary>
        /// <param name="vector">The vector from which the point is created.</param>
        /// <typeparam name="TScalar">The type of the components of the point.</typeparam>
        /// <returns>A new <see cref="Point2{T}" /> with its components set to the components of the vector.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point2<TScalar> Create<TScalar>(Vector2<TScalar> vector)
            where TScalar : IAdditionOperators<TScalar, TScalar, TScalar>,
            IAdditiveIdentity<TScalar, TScalar>,
            IMultiplyOperators<TScalar, TScalar, TScalar>,
            ISubtractionOperators<TScalar, TScalar, TScalar>,
            IUnaryNegationOperators<TScalar, TScalar>,
            IDivisionOperators<TScalar, TScalar, TScalar>
            => new(vector.X, vector.Y);

        /// <summary>Gets a point whose components are equal to zero.</summary>
        /// <typeparam name="TScalar">The type of the components of the point.</typeparam>
        /// <value>A point whose components are equal to zero.</value>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point2<TScalar> Zero<TScalar>()
            where TScalar : IAdditionOperators<TScalar, TScalar, TScalar>,
            IMultiplyOperators<TScalar, TScalar, TScalar>,
            ISubtractionOperators<TScalar, TScalar, TScalar>,
            IUnaryNegationOperators<TScalar, TScalar>,
            IDivisionOperators<TScalar, TScalar, TScalar>,
            IAdditiveIdentity<TScalar, TScalar>
            => new(TScalar.AdditiveIdentity);

        /// <summary>Gets a point whose components are equal to one.</summary>
        /// <typeparam name="TScalar">The type of the components of the point.</typeparam>
        /// <value>A point whose components are equal to one.</value>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point2<TScalar> One<TScalar>()
            where TScalar : IAdditionOperators<TScalar, TScalar, TScalar>,
            IAdditiveIdentity<TScalar, TScalar>,
            IMultiplyOperators<TScalar, TScalar, TScalar>,
            ISubtractionOperators<TScalar, TScalar, TScalar>,
            IUnaryNegationOperators<TScalar, TScalar>,
            IDivisionOperators<TScalar, TScalar, TScalar>,
            IMultiplicativeIdentity<TScalar, TScalar>
            => new(TScalar.MultiplicativeIdentity);

        /// <summary>Gets the point (1,0).</summary>
        /// <typeparam name="TScalar">The type of the components of the point.</typeparam>
        /// <returns>The point <c>(1,0)</c>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point2<TScalar> UnitX<TScalar>()
            where TScalar : IAdditionOperators<TScalar, TScalar, TScalar>,
            IMultiplyOperators<TScalar, TScalar, TScalar>,
            ISubtractionOperators<TScalar, TScalar, TScalar>,
            IUnaryNegationOperators<TScalar, TScalar>,
            IDivisionOperators<TScalar, TScalar, TScalar>,
            IAdditiveIdentity<TScalar, TScalar>,
            IMultiplicativeIdentity<TScalar, TScalar>
            => new(TScalar.MultiplicativeIdentity, TScalar.AdditiveIdentity);

        /// <summary>Gets the point (0,1,0).</summary>
        /// <typeparam name="TScalar">The type of the components of the point.</typeparam>
        /// <returns>The point <c>(0,1,0)</c>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point2<TScalar> UnitY<TScalar>()
            where TScalar : IAdditionOperators<TScalar, TScalar, TScalar>,
            IMultiplyOperators<TScalar, TScalar, TScalar>,
            ISubtractionOperators<TScalar, TScalar, TScalar>,
            IUnaryNegationOperators<TScalar, TScalar>,
            IDivisionOperators<TScalar, TScalar, TScalar>,
            IAdditiveIdentity<TScalar, TScalar>,
            IMultiplicativeIdentity<TScalar, TScalar>
            => new(TScalar.AdditiveIdentity, TScalar.MultiplicativeIdentity);

        /// <summary>Translates a point by a given vector.</summary>
        /// <param name="left">The point to translate.</param>
        /// <param name="right">The vector to add to the point.</param>
        /// <typeparam name="TScalar">The type of the components of the point and the vector.</typeparam>
        /// <returns>The translated point.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point2<TScalar> Add<TScalar>(Point2<TScalar> left, Vector2<TScalar> right)
            where TScalar : IAdditionOperators<TScalar, TScalar, TScalar>,
            IAdditiveIdentity<TScalar, TScalar>,
            IMultiplyOperators<TScalar, TScalar, TScalar>,
            ISubtractionOperators<TScalar, TScalar, TScalar>,
            IUnaryNegationOperators<TScalar, TScalar>,
            IDivisionOperators<TScalar, TScalar, TScalar>
            => left + right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2<TScalar> Subtract<TScalar>(Point2<TScalar> left, Point2<TScalar> right)
            where TScalar : IAdditionOperators<TScalar, TScalar, TScalar>,
            IAdditiveIdentity<TScalar, TScalar>,
            IMultiplyOperators<TScalar, TScalar, TScalar>,
            ISubtractionOperators<TScalar, TScalar, TScalar>,
            IUnaryNegationOperators<TScalar, TScalar>,
            IDivisionOperators<TScalar, TScalar, TScalar>
            => left - right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point2<TScalar> Subtract<TScalar>(Point2<TScalar> left, Vector2<TScalar> right)
            where TScalar : IAdditionOperators<TScalar, TScalar, TScalar>,
            IAdditiveIdentity<TScalar, TScalar>,
            IMultiplyOperators<TScalar, TScalar, TScalar>,
            ISubtractionOperators<TScalar, TScalar, TScalar>,
            IUnaryNegationOperators<TScalar, TScalar>,
            IDivisionOperators<TScalar, TScalar, TScalar>
            => left - right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TScalar DistanceSquared<TScalar>(Point2<TScalar> value1, Point2<TScalar> value2)
            where TScalar : IAdditionOperators<TScalar, TScalar, TScalar>,
            IAdditiveIdentity<TScalar, TScalar>,
            IMultiplyOperators<TScalar, TScalar, TScalar>,
            ISubtractionOperators<TScalar, TScalar, TScalar>,
            IUnaryNegationOperators<TScalar, TScalar>,
            IDivisionOperators<TScalar, TScalar, TScalar>
            => (value1 - value2).LengthSquared();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TScalar Distance<TScalar>(Point2<TScalar> value1, Point2<TScalar> value2)
            where TScalar : IAdditionOperators<TScalar, TScalar, TScalar>,
            IMultiplyOperators<TScalar, TScalar, TScalar>,
            ISubtractionOperators<TScalar, TScalar, TScalar>,
            IUnaryNegationOperators<TScalar, TScalar>,
            IDivisionOperators<TScalar, TScalar, TScalar>,
            IRootFunctions<TScalar>
            => (value1 - value2).Length();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point2<TScalar> Lerp<TScalar>(Point2<TScalar> value1, Point2<TScalar> value2, TScalar amount)
            where TScalar : IAdditionOperators<TScalar, TScalar, TScalar>,
            IAdditiveIdentity<TScalar, TScalar>,
            IMultiplyOperators<TScalar, TScalar, TScalar>,
            ISubtractionOperators<TScalar, TScalar, TScalar>,
            IUnaryNegationOperators<TScalar, TScalar>,
            IDivisionOperators<TScalar, TScalar, TScalar>,
            IMultiplicativeIdentity<TScalar, TScalar>
        {
            var combination = Vector2.Lerp(value1.AsVector2(), value2.AsVector2(), amount);
            return Create(combination);
        }
    }
}
