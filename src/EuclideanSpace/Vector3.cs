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
        internal const int Count = 3;

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

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3<TScalar> Create<TScalar>(TScalar x, TScalar y, TScalar z)
            where TScalar : IAdditionOperators<TScalar, TScalar, TScalar>,
            IAdditiveIdentity<TScalar, TScalar>,
            IMultiplyOperators<TScalar, TScalar, TScalar>,
            ISubtractionOperators<TScalar, TScalar, TScalar>,
            IUnaryNegationOperators<TScalar, TScalar>,
            IDivisionOperators<TScalar, TScalar, TScalar>
            => new(x, y, z);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3<TScalar> Create<TScalar>(ReadOnlySpan<TScalar> elements)
            where TScalar : IAdditionOperators<TScalar, TScalar, TScalar>,
            IAdditiveIdentity<TScalar, TScalar>,
            IMultiplyOperators<TScalar, TScalar, TScalar>,
            ISubtractionOperators<TScalar, TScalar, TScalar>,
            IUnaryNegationOperators<TScalar, TScalar>,
            IDivisionOperators<TScalar, TScalar, TScalar>
        {
            if (elements.Length < Count)
                ThrowHelpers.ThrowArgumentOutOfRangeException(nameof(elements));

            return new(elements[0], elements[1], elements[2]);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3<TScalar> Zero<TScalar>()
            where TScalar : IAdditionOperators<TScalar, TScalar, TScalar>,
            IMultiplyOperators<TScalar, TScalar, TScalar>,
            ISubtractionOperators<TScalar, TScalar, TScalar>,
            IUnaryNegationOperators<TScalar, TScalar>,
            IDivisionOperators<TScalar, TScalar, TScalar>,
            IAdditiveIdentity<TScalar, TScalar>
            => new(TScalar.AdditiveIdentity);

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
