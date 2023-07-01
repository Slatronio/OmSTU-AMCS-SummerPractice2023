namespace XUnit.Coverlet.MSBuild;
using SquareEquationLib;

public class UnitTest1
{
    [Theory]
    [InlineData(0, 1, 8)]
    [InlineData(double.PositiveInfinity, 6, 2)]
    [InlineData(1, double.PositiveInfinity, 2)]
    [InlineData(1, 4, double.PositiveInfinity)]
    [InlineData(double.NegativeInfinity, 2, 7)]
    [InlineData(1, double.NegativeInfinity, 2)]
    [InlineData(1, 1, double.NegativeInfinity)]
    [InlineData(double.NaN, 2, 2)]
    [InlineData(1, double.NaN, 1)]
    [InlineData(1, 1, double.NaN)]
    public void TestArgumentException(double a, double b, double c)
    {
        Assert.Throws<ArgumentException>(() => SquareEquation.Solve(a, b, c));
    }

    [Theory]
    [InlineData(5, 10, 5, -1, 9)]
    [InlineData(6, -12, 6, 1, 9)]
    [InlineData(4, 32, 64, -4, 9)]
    public void TestOne(double a, double b, double c, double expected, int precision)
    {
        double[] testOneSolve = SquareEquation.Solve(a, b, c);
        Assert.Equal(expected, testOneSolve[0], precision);
    }

    [Theory]
    [InlineData(1, 17, -18, -18, 1, 9)]
    [InlineData(5, 7, 2, -1, -0.4, 9)]
    [InlineData(1, -11, 18, 9, 2, 9)]
    public void TestTwo(double a, double b, double c, double expected1, double expected2,  int precision)
    {
        double[] testTwoSolve = SquareEquation.Solve(a, b, c);
        double[] expected = {expected1, expected2};
        Assert.True(testTwoSolve.Length == expected.Length);
        for (int i = 0; i < testTwoSolve.Length; i++)
        {
            Assert.Equal(expected[i], testTwoSolve[i], precision);
        }
    }
    
    [Theory]
    [InlineData(1, 8, 25)]
    [InlineData(2, 16, 38)]
    [InlineData(1, 5, 100)]
    [InlineData(8, -24, 200)]
    public void TestNegative(double a, double b, double c)
    {
        double[] test = SquareEquation.Solve(a, b, c);
        Assert.Empty(test);
    }
}