using Xunit;

namespace EuclideanSpace;

public sealed class Vector2_Tests
{
    public static TheoryData<Vector2<int>, Vector2<int>, int> DotTheoryData { get; } = CreateDotTheoryData();

    public static TheoryData<Vector2<int>, Vector2<int>, int> CrossTheoryData { get; } = CreateCrossTheoryData();

    public static TheoryData<Vector2<float>, Vector2<float>, double, Vector2<float>>
        LerpSingleDoubleTheoryData { get; } = CreateLerpSingleDoubleTheoryData();

    public static TheoryData<Vector2<decimal>, Vector2<decimal>, decimal, Vector2<decimal>>
        LerpDecimalTheoryData { get; } = CreateLerpDecimalTheoryData();

    [Theory]
    [MemberData(nameof(DotTheoryData))]
    public void Dot(Vector2<int> left, Vector2<int> right, int expected)
    {
        int actual = Vector2.Dot(left, right);
        Assert.Equal(expected, actual);
    }

    [Theory]
    [MemberData(nameof(CrossTheoryData))]
    public void Cross(Vector2<int> left, Vector2<int> right, int expected)
    {
        int actual = Vector2.Cross(left, right);
        Assert.Equal(expected, actual);
    }

    [Theory]
    [MemberData(nameof(LerpSingleDoubleTheoryData))]
    public void Lerp_SingleDouble(Vector2<float> first, Vector2<float> second, double amount, Vector2<float> expected)
    {
        var actual = Vector2.Lerp(first, second, amount);
        Assert.Equal(expected, actual, Vector2TolerantComparer.Default<float>());
    }

    [Theory]
    [MemberData(nameof(LerpDecimalTheoryData))]
    public void Lerp_Decimal(Vector2<decimal> first, Vector2<decimal> second, decimal amount, Vector2<decimal> expected)
    {
        var actual = Vector2.Lerp<decimal>(first, second, amount);
        Assert.Equal(expected, actual, Vector2TolerantComparer.Default<decimal>());
    }

    [Fact]
    public void Indexer()
    {
        Vector2<short> vector = new(3, 5);
        Assert.Equal(3, vector[0]);
        Assert.Equal(5, vector[1]);
    }

    private static TheoryData<Vector2<int>, Vector2<int>, int> CreateDotTheoryData() => new()
    {
        { Vector2.UnitX<int>(), Vector2.UnitY<int>(), 0 },
        { new(2, 3), new(6, -4), 0 },
        { new(2, 3), new(5, 7), 31 },
        { new(3, 4), new(3, 4), 25 }
    };

    private static TheoryData<Vector2<int>, Vector2<int>, int> CreateCrossTheoryData() => new()
    {
        { Vector2.UnitX<int>(), Vector2.UnitY<int>(), 1 },
        { Vector2.UnitY<int>(), Vector2.UnitX<int>(), -1 },
        { new(3, 4), new(3, 4), 0 },
        { new(3, 4), new(4, -3), -25 }
    };

    private static TheoryData<Vector2<float>, Vector2<float>, double, Vector2<float>>
        CreateLerpSingleDoubleTheoryData() => new()
    {
        { new(-2f, -1f), new(1f, 5f), 2.0 / 3.0, new(0f, 3f) }
    };

    private static TheoryData<Vector2<decimal>, Vector2<decimal>, decimal, Vector2<decimal>>
        CreateLerpDecimalTheoryData() => new()
    {
        { new(-2m, -1m), new(1m, 5m), 2m / 3m, new(0m, 3m) }
    };
}
