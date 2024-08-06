using System;
using Xunit;

namespace EuclideanSpace;

public sealed class Point2_Tests
{
    [Fact]
    public void Indexer()
    {
        Point2<short> point = new(5, 8);
        Assert.Equal(5, point[0]);
        Assert.Equal(8, point[1]);
    }

    [Fact]
    public void Add()
    {
        var point = Point2.Create(3, 4);
        var vector = Vector2.Create(2, -5);
        var expected = Point2.Create(5, -1);
        var actual = point + vector;
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Subtract()
    {
        var first = Point2Conversions<Half>.Create(5, -1);
        var second = Point2Conversions<Half>.Create(3, 4);
        var expected = Vector2Conversions<Half>.Create(2, -5);
        var actual = first - second;
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Distance()
    {
        var first = Point2.Create(-1f, -2f);
        var second = Point2.Create(3f, 1f);
        const float expected = 5f;
        float actual = Point2.Distance(first, second);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Lerp_SingleDouble()
    {
        var first = Point2.Create(-2f, -1f);
        var second = Point2.Create(1f, 5f);
        const double amount = 2.0 / 3.0;
        var expected = Point2.Create(0f, 3f);
        var actual = Point2Conversions.Lerp(first, second, amount);
        Assert.Equal(expected, actual, Point2TolerantComparer.Default<float>());
    }

    [Fact]
    public void Lerp_Decimal()
    {
        var first = Point2.Create(-2m, -1m);
        var second = Point2.Create(1m, 5m);
        const decimal amount = 2m / 3m;
        var expected = Point2.Create(0m, 3m);
        var actual = Point2.Lerp(first, second, amount);
        Assert.Equal(expected, actual, Point2TolerantComparer.Default<decimal>());
    }
}
