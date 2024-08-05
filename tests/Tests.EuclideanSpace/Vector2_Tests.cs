using Xunit;

namespace EuclideanSpace;

public sealed class Vector2_Tests
{
    public static TheoryData<Vector2<int>, Vector2<int>, int> DotTheoryData { get; } = CreateDotTheoryData();

    [Theory]
    [MemberData(nameof(DotTheoryData), MemberType = typeof(Vector2_Tests))]
    public void Dot(Vector2<int> left, Vector2<int> right, int expected)
    {
        int actual = Vector2.Dot(left, right);
        Assert.Equal(expected, actual);
    }

    private static TheoryData<Vector2<int>, Vector2<int>, int> CreateDotTheoryData() => new()
    {
        { new(2, 3), new(6, -4), 0 },
        { new(2, 3), new(5, 7), 31 },
        { new(3, 4), new(3, 4), 25 }
    };
}
