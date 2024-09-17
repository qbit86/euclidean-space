using System;
using System.Collections.Generic;
using System.Numerics;

namespace EuclideanSpace;

public static class Point2TolerantComparer
{
    public static Point2TolerantComparer<T> Default<T>() where T : INumberBase<T>, IComparable<T> =>
        Helpers<T>.DefaultComparer;
}

public sealed class Point2TolerantComparer<TScalar> : IEqualityComparer<Point2<TScalar>>
    where TScalar : INumberBase<TScalar>, IComparable<TScalar>
{
    private readonly TScalar _tolerance;

    public Point2TolerantComparer(TScalar tolerance)
    {
        if (tolerance is null)
            throw new ArgumentNullException(nameof(tolerance));

        _tolerance = tolerance;
    }

    public bool Equals(Point2<TScalar> x, Point2<TScalar> y) => EqualsCore(x.X, y.X) && EqualsCore(x.Y, y.Y);

    public int GetHashCode(Point2<TScalar> obj) => obj.GetHashCode();

    private bool EqualsCore(TScalar x, TScalar y)
    {
        var difference = TScalar.Abs(y - x);
        return difference.CompareTo(_tolerance) <= 0;
    }
}

file static class Helpers<T> where T : INumberBase<T>, IComparable<T>
{
    internal static readonly Point2TolerantComparer<T> DefaultComparer = new(T.CreateChecked(Half.Epsilon));
}
