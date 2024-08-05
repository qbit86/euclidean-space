using Xunit;

namespace EuclideanSpace;

public sealed class Vector2_Tests
{
    public static TheoryData<Vector2<int>, Vector2<int>, int> DotTheoryData { get; } = CreateDotTheoryData();

    public static TheoryData<Vector2<int>, Vector2<int>, int> CrossTheoryData { get; } = CreateCrossTheoryData();

    [Theory]
    [MemberData(nameof(DotTheoryData), MemberType = typeof(Vector2_Tests))]
    public void Dot(Vector2<int> left, Vector2<int> right, int expected)
    {
        int actual = Vector2.Dot(left, right);
        Assert.Equal(expected, actual);
    }

    [Theory]
    [MemberData(nameof(CrossTheoryData), MemberType = typeof(Vector2_Tests))]
    public void Cross(Vector2<int> left, Vector2<int> right, int expected)
    {
        int actual = Vector2.Cross(left, right);
        Assert.Equal(expected, actual);
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
}
