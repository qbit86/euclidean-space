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
        internal const int Count = Vector2.Count;

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

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point2<TScalar> Create<TScalar>(TScalar x, TScalar y)
            where TScalar : IAdditionOperators<TScalar, TScalar, TScalar>,
            IAdditiveIdentity<TScalar, TScalar>,
            IMultiplyOperators<TScalar, TScalar, TScalar>,
            ISubtractionOperators<TScalar, TScalar, TScalar>,
            IUnaryNegationOperators<TScalar, TScalar>,
            IDivisionOperators<TScalar, TScalar, TScalar>
            => new(x, y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point2<TScalar> Create<TScalar>(ReadOnlySpan<TScalar> elements)
            where TScalar : IAdditionOperators<TScalar, TScalar, TScalar>,
            IAdditiveIdentity<TScalar, TScalar>,
            IMultiplyOperators<TScalar, TScalar, TScalar>,
            ISubtractionOperators<TScalar, TScalar, TScalar>,
            IUnaryNegationOperators<TScalar, TScalar>,
            IDivisionOperators<TScalar, TScalar, TScalar>
        {
            if (elements.Length < Count)
                ThrowHelpers.ThrowArgumentOutOfRangeException(nameof(elements));

            return new(elements[0], elements[1]);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point2<TScalar> Create<TScalar>(Vector2<TScalar> vector)
            where TScalar : IAdditionOperators<TScalar, TScalar, TScalar>,
            IAdditiveIdentity<TScalar, TScalar>,
            IMultiplyOperators<TScalar, TScalar, TScalar>,
            ISubtractionOperators<TScalar, TScalar, TScalar>,
            IUnaryNegationOperators<TScalar, TScalar>,
            IDivisionOperators<TScalar, TScalar, TScalar>
            => new(vector.X, vector.Y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point2<TScalar> Zero<TScalar>()
            where TScalar : IAdditionOperators<TScalar, TScalar, TScalar>,
            IMultiplyOperators<TScalar, TScalar, TScalar>,
            ISubtractionOperators<TScalar, TScalar, TScalar>,
            IUnaryNegationOperators<TScalar, TScalar>,
            IDivisionOperators<TScalar, TScalar, TScalar>,
            IAdditiveIdentity<TScalar, TScalar>
            => new(TScalar.AdditiveIdentity);

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
