namespace EuclideanSpace
{
    using System;
    using System.Numerics;
    using System.Runtime.CompilerServices;

    /// <summary>
    /// Provides a collection of static methods for creating, manipulating, and otherwise operating on generic points.
    /// </summary>
    public static partial class Point3
    {
        /// <summary>
        /// Gets the number of components that are in a <see cref="Point3{T}" />.
        /// </summary>
        public const int Count = Vector3.Count;

        /// <summary>
        /// Creates a new <see cref="Point3{T}" /> instance with all components initialized to the specified value.
        /// </summary>
        /// <param name="value">The value that all components will be initialized to.</param>
        /// <typeparam name="TScalar">The type of the components of the point.</typeparam>
        /// <returns>A new <see cref="Point3{T}" /> with all components initialized to <paramref name="value" />.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point3<TScalar> Create<TScalar>(TScalar value)
            where TScalar : IAdditionOperators<TScalar, TScalar, TScalar>,
            IAdditiveIdentity<TScalar, TScalar>,
            IMultiplyOperators<TScalar, TScalar, TScalar>,
            ISubtractionOperators<TScalar, TScalar, TScalar>,
            IUnaryNegationOperators<TScalar, TScalar>,
            IDivisionOperators<TScalar, TScalar, TScalar>
            => new(value);

        /// <summary>
        /// Creates a new <see cref="Point3{T}" /> instance with all components initialized to the specified values.
        /// </summary>
        /// <param name="x">The value to assign to the <see cref="Point3{T}.X" /> component.</param>
        /// <param name="y">The value to assign to the <see cref="Point3{T}.Y" /> component.</param>
        /// <param name="z">The value to assign to the <see cref="Point3{T}.Z" /> component.</param>
        /// <typeparam name="TScalar">The type of the components of the point.</typeparam>
        /// <returns>A new <see cref="Point3{T}" /> with all components initialized to the specified values.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point3<TScalar> Create<TScalar>(TScalar x, TScalar y, TScalar z)
            where TScalar : IAdditionOperators<TScalar, TScalar, TScalar>,
            IAdditiveIdentity<TScalar, TScalar>,
            IMultiplyOperators<TScalar, TScalar, TScalar>,
            ISubtractionOperators<TScalar, TScalar, TScalar>,
            IUnaryNegationOperators<TScalar, TScalar>,
            IDivisionOperators<TScalar, TScalar, TScalar>
            => new(x, y, z);

        /// <summary>
        /// Creates a new <see cref="Point3{T}" /> from a given readonly span.
        /// </summary>
        /// <param name="values">The readonly span from which the point is created.</param>
        /// <typeparam name="TScalar">The type of the components of the point.</typeparam>
        /// <returns>A new <see cref="Point3{T}" /> with its components set to the first <see cref="Point3.Count" /> elements from <paramref name="values" />.</returns>
        /// <exception cref="ArgumentOutOfRangeException">The length of <paramref name="values" /> is less than <see cref="Point3.Count" />.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point3<TScalar> Create<TScalar>(ReadOnlySpan<TScalar> values)
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

        /// <summary>
        /// Creates a new <see cref="Point3{T}" /> from a given vector.
        /// </summary>
        /// <param name="vector">The vector from which the point is created.</param>
        /// <typeparam name="TScalar">The type of the components of the point.</typeparam>
        /// <returns>A new <see cref="Point3{T}" /> with its components set to the components of the vector.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point3<TScalar> Create<TScalar>(Vector3<TScalar> vector)
            where TScalar : IAdditionOperators<TScalar, TScalar, TScalar>,
            IAdditiveIdentity<TScalar, TScalar>,
            IMultiplyOperators<TScalar, TScalar, TScalar>,
            ISubtractionOperators<TScalar, TScalar, TScalar>,
            IUnaryNegationOperators<TScalar, TScalar>,
            IDivisionOperators<TScalar, TScalar, TScalar>
            => new(vector.X, vector.Y, vector.Z);

        /// <summary>Gets a point whose components are equal to zero.</summary>
        /// <typeparam name="TScalar">The type of the components of the point.</typeparam>
        /// <value>A point whose components are equal to zero.</value>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point3<TScalar> Zero<TScalar>()
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
        public static Point3<TScalar> One<TScalar>()
            where TScalar : IAdditionOperators<TScalar, TScalar, TScalar>,
            IAdditiveIdentity<TScalar, TScalar>,
            IMultiplyOperators<TScalar, TScalar, TScalar>,
            ISubtractionOperators<TScalar, TScalar, TScalar>,
            IUnaryNegationOperators<TScalar, TScalar>,
            IDivisionOperators<TScalar, TScalar, TScalar>,
            IMultiplicativeIdentity<TScalar, TScalar>
            => new(TScalar.MultiplicativeIdentity);

        /// <summary>Gets the point (1,0,0).</summary>
        /// <typeparam name="TScalar">The type of the components of the point.</typeparam>
        /// <returns>The point <c>(1,0,0)</c>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point3<TScalar> UnitX<TScalar>()
            where TScalar : IAdditionOperators<TScalar, TScalar, TScalar>,
            IMultiplyOperators<TScalar, TScalar, TScalar>,
            ISubtractionOperators<TScalar, TScalar, TScalar>,
            IUnaryNegationOperators<TScalar, TScalar>,
            IDivisionOperators<TScalar, TScalar, TScalar>,
            IAdditiveIdentity<TScalar, TScalar>,
            IMultiplicativeIdentity<TScalar, TScalar>
            => new(TScalar.MultiplicativeIdentity, TScalar.AdditiveIdentity, TScalar.AdditiveIdentity);

        /// <summary>Gets the point (0,1,0).</summary>
        /// <typeparam name="TScalar">The type of the components of the point.</typeparam>
        /// <returns>The point <c>(0,1,0)</c>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point3<TScalar> UnitY<TScalar>()
            where TScalar : IAdditionOperators<TScalar, TScalar, TScalar>,
            IMultiplyOperators<TScalar, TScalar, TScalar>,
            ISubtractionOperators<TScalar, TScalar, TScalar>,
            IUnaryNegationOperators<TScalar, TScalar>,
            IDivisionOperators<TScalar, TScalar, TScalar>,
            IAdditiveIdentity<TScalar, TScalar>,
            IMultiplicativeIdentity<TScalar, TScalar>
            => new(TScalar.AdditiveIdentity, TScalar.MultiplicativeIdentity, TScalar.AdditiveIdentity);

        /// <summary>Gets the point (0,0,1).</summary>
        /// <typeparam name="TScalar">The type of the components of the point.</typeparam>
        /// <returns>The point <c>(0,0,1)</c>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point3<TScalar> UnitZ<TScalar>()
            where TScalar : IAdditionOperators<TScalar, TScalar, TScalar>,
            IMultiplyOperators<TScalar, TScalar, TScalar>,
            ISubtractionOperators<TScalar, TScalar, TScalar>,
            IUnaryNegationOperators<TScalar, TScalar>,
            IDivisionOperators<TScalar, TScalar, TScalar>,
            IAdditiveIdentity<TScalar, TScalar>,
            IMultiplicativeIdentity<TScalar, TScalar>
            => new(TScalar.AdditiveIdentity, TScalar.AdditiveIdentity, TScalar.MultiplicativeIdentity);

        /// <summary>Translates a point by a given vector.</summary>
        /// <param name="left">The point to translate.</param>
        /// <param name="right">The vector to add to the point.</param>
        /// <typeparam name="TScalar">The type of the components of the point and the vector.</typeparam>
        /// <returns>The translated point.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point3<TScalar> Add<TScalar>(Point3<TScalar> left, Vector3<TScalar> right)
            where TScalar : IAdditionOperators<TScalar, TScalar, TScalar>,
            IAdditiveIdentity<TScalar, TScalar>,
            IMultiplyOperators<TScalar, TScalar, TScalar>,
            ISubtractionOperators<TScalar, TScalar, TScalar>,
            IUnaryNegationOperators<TScalar, TScalar>,
            IDivisionOperators<TScalar, TScalar, TScalar>
            => left + right;

        /// <summary>Subtracts two points to compute their difference.</summary>
        /// <param name="left">The point from which <paramref name="right" /> will be subtracted.</param>
        /// <param name="right">The point to subtract from <paramref name="left" />.</param>
        /// <typeparam name="TScalar">The type of the components of the vector.</typeparam>
        /// <returns>The vector that is the result of the subtraction operation.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3<TScalar> Subtract<TScalar>(Point3<TScalar> left, Point3<TScalar> right)
            where TScalar : IAdditionOperators<TScalar, TScalar, TScalar>,
            IAdditiveIdentity<TScalar, TScalar>,
            IMultiplyOperators<TScalar, TScalar, TScalar>,
            ISubtractionOperators<TScalar, TScalar, TScalar>,
            IUnaryNegationOperators<TScalar, TScalar>,
            IDivisionOperators<TScalar, TScalar, TScalar>
            => left - right;

        /// <summary>Subtracts specified vector from the specified point.</summary>
        /// <param name="left">The point to be subtracted from.</param>
        /// <param name="right">The vector to subtract from the point.</param>
        /// <typeparam name="TScalar">The type of the components of the point and the vector.</typeparam>
        /// <returns>The point that is the result of the subtraction operation.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point3<TScalar> Subtract<TScalar>(Point3<TScalar> left, Vector3<TScalar> right)
            where TScalar : IAdditionOperators<TScalar, TScalar, TScalar>,
            IAdditiveIdentity<TScalar, TScalar>,
            IMultiplyOperators<TScalar, TScalar, TScalar>,
            ISubtractionOperators<TScalar, TScalar, TScalar>,
            IUnaryNegationOperators<TScalar, TScalar>,
            IDivisionOperators<TScalar, TScalar, TScalar>
            => left - right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TScalar DistanceSquared<TScalar>(Point3<TScalar> value1, Point3<TScalar> value2)
            where TScalar : IAdditionOperators<TScalar, TScalar, TScalar>,
            IAdditiveIdentity<TScalar, TScalar>,
            IMultiplyOperators<TScalar, TScalar, TScalar>,
            ISubtractionOperators<TScalar, TScalar, TScalar>,
            IUnaryNegationOperators<TScalar, TScalar>,
            IDivisionOperators<TScalar, TScalar, TScalar>
            => (value1 - value2).LengthSquared();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TScalar Distance<TScalar>(Point3<TScalar> value1, Point3<TScalar> value2)
            where TScalar : IAdditionOperators<TScalar, TScalar, TScalar>,
            IMultiplyOperators<TScalar, TScalar, TScalar>,
            ISubtractionOperators<TScalar, TScalar, TScalar>,
            IUnaryNegationOperators<TScalar, TScalar>,
            IDivisionOperators<TScalar, TScalar, TScalar>,
            IRootFunctions<TScalar>
            => (value1 - value2).Length();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point3<TScalar> Lerp<TScalar>(Point3<TScalar> value1, Point3<TScalar> value2, TScalar amount)
            where TScalar : IAdditionOperators<TScalar, TScalar, TScalar>,
            IAdditiveIdentity<TScalar, TScalar>,
            IMultiplyOperators<TScalar, TScalar, TScalar>,
            ISubtractionOperators<TScalar, TScalar, TScalar>,
            IUnaryNegationOperators<TScalar, TScalar>,
            IDivisionOperators<TScalar, TScalar, TScalar>,
            IMultiplicativeIdentity<TScalar, TScalar>
        {
            var combination = Vector3.Lerp(value1.AsVector3(), value2.AsVector3(), amount);
            return Create(combination);
        }
    }
}
