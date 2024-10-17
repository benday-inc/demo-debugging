using Benday.DebuggingDemo.Api;

namespace Benday.DebuggingDemo.UnitTests;

public class NameFixture
{
    [Theory]
    [InlineData("", "", false)]
    [InlineData(".", ",", false)]
    [InlineData("Betty", "", false)]
    [InlineData("", "Mooks", false)]
    [InlineData("Betty", "Mooks", true)]
    public void IsValid(string firstName, string lastName, bool expected)
    {
        // arrange
        var systemUnderTest = new Name()
        {
            FirstName = firstName,
            LastName = lastName
        };

        // act
        var actual = systemUnderTest.IsValid();

        // assert
        if (expected == true)
        {
            Assert.True(actual, "Expected IsValid to return true.");
        }
        else
        {
            Assert.False(actual, "Expected IsValid to return false.");
        }
    }

    [Theory]
    [InlineData("", "", "")]
    [InlineData(".", ",", ". ,")]
    [InlineData("Betty", "", "Betty (Unknown)")]
    [InlineData("", "Mooks", "(Unknown) Mooks")]
    [InlineData("Betty", "Mooks", "Betty Mooks")]
    public void ToString_Value(string firstName, string lastName, string expected)
    {
        // arrange
        var systemUnderTest = new Name()
        {
            FirstName = firstName,
            LastName = lastName
        };

        // act
        var actual = systemUnderTest.ToString();

        // assert
        Assert.Equal(expected, actual);
    }
}