using Xunit;

namespace EuclideanSpace;

public sealed class Vector3_Tests
{
    public static TheoryData<Vector3<int>, Vector3<int>, Vector3<int>> SubtractTheoryData { get; } =
        CreateSubtractTheoryData();

    [Theory]
    [MemberData(nameof(SubtractTheoryData))]
    public void Subtract(Vector3<int> left, Vector3<int> right, Vector3<int> expected)
    {
        var actual = left - right;
        Assert.Equal(expected, actual);
    }

    private static TheoryData<Vector3<int>, Vector3<int>, Vector3<int>> CreateSubtractTheoryData() => new()
    {
        { new(8, 5, 3), new(5, 7, 11), new(3, -2, -8) },
        { new(5, 7, 11), Vector3.Zero<int>(), new(5, 7, 11) },
        { new(5, 7, 11), new(5, 7, 11), Vector3.Zero<int>() }
    };
}
